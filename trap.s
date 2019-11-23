
	.kdata
__m1_:	.asciiz "  Exception "
__m2_:	.asciiz " Execution aborted\n"
__e0_:	.asciiz "  [Interrupt] "
__e1_:	.asciiz	""
__e2_:	.asciiz	""
__e3_:	.asciiz	""
__e4_:	.asciiz	"  [Unaligned address in inst/data fetch] "
__e5_:	.asciiz	"  [Unaligned address in store] "
__e6_:	.asciiz	"  [Bad address in text read] "
__e7_:	.asciiz	"  [Bad address in data/stack read] "
__e8_:	.asciiz	"  [Error in syscall] "
__e9_:	.asciiz	"  [Breakpoint/Division by 0] "
__e10_:	.asciiz	"  [Reserved instruction] "
__e11_:	.asciiz	""
__e12_:	.asciiz	"  [Arithmetic overflow] "
__e13_:	.asciiz	"  [Inexact floating point result] "
__e14_:	.asciiz	"  [Invalid floating point result] "
__e15_:	.asciiz	"  [Divide by 0] "
__e16_:	.asciiz	"  [Floating point overflow] "
__e17_:	.asciiz	"  [Floating point underflow] "
__excp:	.word __e0_,__e1_,__e2_,__e3_,__e4_,__e5_,__e6_,__e7_,__e8_,__e9_
	.word __e10_,__e11_,__e12_,__e13_,__e14_,__e15_,__e16_,__e17_
s1:	.word 0
s2:	.word 0

	.ktext 0x80000080
	.set noat

	move $at $k1	
	.set at
	sw $v0 s1	
	sw $a0 s2
	mfc0 $k0 $13	
        sgt $v0 $k0 0x44 # ignore interrupt exceptions
        bgtz $v0 ret
        addu $0 $0 0
	li $v0 4	# syscall 4 (print_str)
	la $a0 __m1_
	syscall
	li $v0 1	# syscall 1 (print_int)
        srl $a0 $k0 2
	syscall
	li $v0 4	# syscall 4 (print_str)
	lw $a0 __excp($k0)
	syscall
	li $v0 4
	la $a0 __m2_
	syscall
	li $v0 10	# Exit upon all exceptions
	syscall		# syscall 10 (exit)
ret:	lw $v0 s1
	lw $a0 s2
	mfc0 $k0 $14	
	.set noat
	move $k1 $at	
	.set at
	rfe		# Return from exception handler
	addiu $k0 $k0 4 # Return to next instruction
	jr $k0

#Up for SPIM
#DOWN for COOL RUNTIME



# Standard startup code.  Invoke the routine main with no arguments.
	.data

_abort_msg:	.asciiz "Abort called from class "
_colon_msg:	.asciiz ":"
_dispatch_msg:  .asciiz ": Dispatch to void.\n"
_cabort_msg:	.asciiz "No match in case statement for Class "
_cabort_msg2:   .asciiz "Match on void in case statement.\n"
_nl:		.asciiz "\n"
_term_msg:	.asciiz "COOL program successfully executed\n"
_sabort_msg1:	.asciiz	"Index to substr is negative\n"
_sabort_msg2:	.asciiz	"Index to substr is too big\n"
_sabort_msg3:	.asciiz	"Length to substr too long\n"
_sabort_msg4:	.asciiz	"Length to substr is negative\n"
_sabort_msg:	.asciiz "Execution aborted.\n"
_objcopy_msg:	.asciiz "Object.copy: Invalid object size.\n"
_gc_abort_msg:	.asciiz "GC bug!\n"

#
# Messages for the GenGC garabge collector
#

_GenGC_INITERROR:	.asciiz "GenGC: Unable to initialize the garbage collector.\n"
_GenGC_COLLECT:		.asciiz "Garbage collecting ...\n"
_GenGC_Major:		.asciiz "Major ...\n"
_GenGC_Minor:		.asciiz "Minor ...\n"
#_GenGC_COLLECT:		.asciiz ""
_GenGC_MINORERROR:	.asciiz "GenGC: Error during minor garbage collection.\n"
_GenGC_MAJORERROR:	.asciiz "GenGC: Error during major garbage collection.\n"

#
# Messages for the NoGC garabge collector
#

_NoGC_COLLECT:		.asciiz "Increasing heap...\n"
#_NoGC_COLLECT:		.asciiz ""

	.align 2

#
# Define some constants
#

obj_eyecatch=-4	# Unique id to verify any object
obj_tag=0
obj_size=4
obj_disp=8
obj_attr=12
int_slot=12
bool_slot=12
str_size=12	# This is a pointer to an Int object!!!
str_field=16	# The beginning of the ascii sequence
str_maxsize=1026	# the maximum string length


MemMgr_REG_MASK=0x007F0000

	.text
	.globl __start
__start:
	li	$v0 9
	move	$a0 $zero
	syscall				# sbrk
	move	$a0 $sp			# initialize the garbage collector
	li	$a1 MemMgr_REG_MASK
	move	$a2 $v0
	jal	_MemMgr_Init		
	la	$a0 Main_protObj	# create the Main object
	jal	Object.copy		# Call copy
	addiu	$sp $sp -4
	sw	$a0 4($sp)		# save the Main object on the stack
	move	$s0 $a0			
	jal	Main_init		# initialize the Main object
	jal	Main.main		# Invoke main method
	addiu	$sp $sp 4		
	la	$a0 _term_msg		# show terminal message
	li	$v0 4
	syscall
	li $v0 10
	syscall				# syscall 10 (exit)



	.globl	equality_test
equality_test:			# ops in $t1 $t2
				# true in A0, false in A1
				
	beq	$t1 $zero _eq_false # $t2 can't also be void   
	beq     $t2 $zero _eq_false # $t1 can't also be void   
	lw	$v0 obj_tag($t1)	# get tags
	lw	$v1 obj_tag($t2)
	bne	$v1 $v0 _eq_false	# compare tags
	lw	$a2 _int_tag	# load int tag
	beq	$v1 $a2 _eq_int	# Integers
	lw	$a2 _bool_tag	# load bool tag
	beq	$v1 $a2 _eq_int	# Booleans
	lw	$a2 _string_tag # load string tag
	bne	$v1 $a2 _eq_false  # Not a primitive type
_eq_str: # handle strings
	lw	$v0, str_size($t1)	# get string size objs
	lw	$v1, str_size($t2)
	lw	$v0, int_slot($v0)	# get string sizes
	lw	$v1, int_slot($v1)
	bne	$v1 $v0 _eq_false
	beqz	$v1 _eq_true		# 0 length strings are equal
	add	$t1 str_field		
	add	$t2 str_field
	move	$t0 $v0		# Keep string length as counter
_eq_l1:
	lbu	$v0,0($t1)	# get char
	add	$t1 1
	lbu	$v1,0($t2)
	add	$t2 1
	bne	$v1 $v0 _eq_false
	addiu	$t0 $t0 -1	
	bnez	$t0 _eq_l1
	b	_eq_true		# end of strings
		
_eq_int:	# handles booleans and ints
	lw	$v0,int_slot($t1)	# load values
	lw	$v1,int_slot($t2)
	bne	$v1 $v0 _eq_false
_eq_true:
	jr	$ra		# return true
_eq_false:
	move	$a0 $a1		# move false into accumulator
	jr	$ra

#
#  _dispatch_abort
#
#      filename in $a0
#      line number in $t1
#  
#  Prints error message and exits.
#  Called on dispatch to void.
#
	.globl	_dispatch_abort
_dispatch_abort:		 
        sw      $t1 0($sp)       # save line number
        addiu   $sp $sp -4
	addiu   $a0 $a0 str_field # adjust to beginning of string
	li      $v0 4
	syscall                  # print file name
	la      $a0 _colon_msg
	li	$v0 4
	syscall                  # print ":"
	lw      $a0 4($sp)       # 
	li	$v0 1
	syscall			 # print line number
	li 	$v0 4
	la	$a0 _dispatch_msg
	syscall			 # print dispatch-to-void message
	li   	$v0 10
        syscall			 # exit


#
#  _case_abort2
#
#      filename in $a0
#      line number in $t1
#  
#  Prints error message and exits.
#  Called on case on void.
#
	.globl	_case_abort2
_case_abort2:		 
        sw      $t1 0($sp)       # save line number
        addiu   $sp $sp -4
	addiu   $a0 $a0 str_field # adjust to beginning of string
	li      $v0 4
	syscall                  # print file name
	la      $a0 _colon_msg
	li	$v0 4
	syscall                  # print ":"
	lw      $a0 4($sp)       # 
	li	$v0 1
	syscall			 # print line number
	li 	$v0 4
	la	$a0 _cabort_msg2
	syscall			 # print case-on-void message
	li   	$v0 10
        syscall			 # exit
	
#
#
#  _case_abort
#		Is called when a case statement has no match
#
#   INPUT:	$a0 contains the object on which the case was
#		performed
#
#   Does not return!
#
	.globl	_case_abort
_case_abort:			# $a0 contains case expression obj.
	move	$s0 $a0		# save the expression object
	la	$a0 _cabort_msg
	li	$v0 4
	syscall			# print_str
	la	$t1 class_nameTab
	lw	$v0 obj_tag($s0)	# Get object tag
	sll	$v0 $v0 2	# *4
	addu	$t1 $t1 $v0
	lw	$t1 0($t1)	# Load class name string obj.
	addiu	$a0 $t1 str_field # Adjust to beginning of str
	li	$v0 4		# print_str
	syscall
	la	$a0 _nl
	li	$v0 4		# print_str
	syscall
	li	$v0 10
	syscall			# Exit
	

#
# Copy method
#
#   INPUT:	$a0: object to be copied to free space in heap
#
#   OUTPUT:	$a0: points to the newly created copy.
#

	.globl	Object.copy
Object.copy:
	addiu	$sp $sp -8			# create stack frame
	sw	$ra 8($sp)
	sw	$a0 4($sp)

	jal	_MemMgr_Test			# test GC area

	lw	$a0 4($sp)			# get object size
	lw	$a0 obj_size($a0)
	blez	$a0 _objcopy_error		# check for invalid size
	sll	$a0 $a0 2			# convert words to bytes
	addiu	$a0 $a0 4			# account for eyecatcher
	jal	_MemMgr_Alloc			# allocate storage
	addiu	$a1 $a0 4			# pointer to new object

	lw	$a0 4($sp)			# the self object
	lw	$ra 8($sp)			# restore return address
	addiu	$sp $sp 8			# remove frame
	lw	$t0 obj_size($a0)		# get size of object
	sll	$t0 $t0 2			# convert words to bytes
	b	_objcopy_allocated		# get on with the copy


_quick_copy:
	lw	$t0 obj_size($a0)		# get size of object to copy
	blez	$t0 _objcopy_error		# check for invalid size
	sll	$t0 $t0 2			# convert words to bytes
	addiu	$t1 $t0 4			
	add	$gp $gp $t1			# allocate memory
	sub	$a1 $gp $t0			# pointer to new object
	blt	$gp $s7 _objcopy_allocated	# check allocation
_objcopy_allocate:
	sub	$gp $a1 4			# restore the original $gp
	addiu	$sp $sp -8			# frame size
	sw	$ra 8($sp)			# save return address
	sw	$a0 4($sp)			# save self
	move	$a0 $t1				# put bytes to allocate in $a0
	jal	_MemMgr_Alloc			# allocate storage
	addiu	$a1 $a0 4			# pointer to new object
	lw	$a0 4($sp)			# the self object
	lw	$ra 8($sp)			# restore return address
	addiu	$sp $sp 8			# remove frame
	lw	$t0 obj_size($a0)		# get size of object
	sll	$t0 $t0 2			# convert words to bytes
_objcopy_allocated:
	addiu	$t1 $0 -1
	sw	$t1 obj_eyecatch($a1)		
	add	$t0 $t0 $a0			# find limit of copy
	move	$t1 $a1				# save source
_objcopy_loop:
	lw	$v0 0($a0)			# copy word
	sw	$v0 0($t1)
	addiu	$a0 $a0 4			# update source
	addiu	$t1 $t1 4			# update destination
	bne	$a0 $t0 _objcopy_loop		# loop
_objcopy_end:
	move	$a0 $a1				# put new object in $a0
	jr	$ra				# return
_objcopy_error:
	la	$a0 _objcopy_msg		# show error message
	li	$v0 4
	syscall
	li	$v0 10				# exit
	syscall

#
#
# Object.abort
#
#   INPUT:	$a0 contains the object on which abort() was dispatched.
#

	.globl	Object.abort
Object.abort:
	move	$s0 $a0		# save self
	li	$v0 4
	la	$a0 _abort_msg
	syscall			# print_str
	la	$t1 class_nameTab
	lw	$v0 obj_tag($s0)	# Get object tag
	sll	$v0 $v0 2	# *4
	addu	$t1 $t1 $v0
	lw	$t1 0($t1)	# Load class name string obj.
	addiu	$a0 $t1 str_field	# Adjust to beginning of str
	li	$v0 4		# print_str
	syscall
	la	$a0 _nl
	li	$v0 4
	syscall			# print new line
	li	$v0 10
	syscall			# Exit

#
#
# Object.type_name	
#
#   	INPUT:	$a0 object who's class name is desired
#	OUTPUT:	$a0 reference to class name string object
#

	.globl	Object.type_name
Object.type_name:
	la	$t1 class_nameTab
	lw	$v0 obj_tag($a0)	# Get object tag
	sll	$v0 $v0 2	# *4
	addu	$t1 $t1 $v0	# index table
	lw	$a0 0($t1)	# Load class name string obj.
	jr	$ra

#
#
# IO.out_string
#

	.globl	IO.out_string
IO.out_string:
	addiu	$sp $sp -4
	sw	$a0 4($sp)	# save self
	lw	$a0 8($sp)	# get arg
	addiu	$a0 $a0 str_field	# Adjust to beginning of str
	li	$v0 4		# print_str
	syscall
	lw	$a0 4($sp)	# return self
	addiu	$sp $sp 8	# pop argument
	jr	$ra

#
#
# IO.out_int

#

	.globl	IO.out_int
IO.out_int:
	addiu	$sp $sp -4
	sw	$a0 4($sp)	# save self
	lw	$a0 8($sp)	# get arg
	lw	$a0 int_slot($a0)	# Fetch int
	li	$v0 1		# print_int
	syscall	
	lw	$a0 4($sp)	# return self
	addiu	$sp $sp 8	# pop argument
	jr	$ra

#
#
# IO.in_int
#

	.globl	IO.in_int
IO.in_int:
	addiu	$sp $sp -4
	sw	$ra 4($sp)	# save return address

        la      $a0 Int_protObj
        jal     _quick_copy	# Call copy
        jal     Int_init

	addiu	$sp $sp -4
	sw	$a0 4($sp)	# save new object

	li	$v0, 5		# read int
	syscall

	lw	$a0 4($sp)
	addiu	$sp $sp 4


	sw	$v0 int_slot($a0)	# store int read into obj
	lw	$ra 4($sp)
	addiu	$sp $sp 4
	jr	$ra

#
#
# IO.in_string

#

	.globl	IO.in_string
IO.in_string:
	addiu	$sp $sp -8
	sw	$ra 8($sp)			# save return address
	sw	$0 4($sp)			# init GC area

	jal	_MemMgr_Test			# test GC area

	la	$a0 Int_protObj			# Int object for string size
	jal	_quick_copy
	jal	Int_init
	sw	$a0 4($sp)			# save it

	li	$a0 str_field			# size of string obj. header
	addiu	$a0 $a0 str_maxsize		# max size of string data
	jal	_MemMgr_QAlloc			# make sure enough room

	la	$a0 String_protObj		# make string object
	jal	_quick_copy
	jal	String_init
	lw	$t0 4($sp)			# get size object
	sw	$t0 str_size($a0)		# store size object in string
	sw	$a0 4($sp)			# save string object

	addiu	$gp $gp -4			# overwrite last word

_instr_ok:
	li	$a1 str_maxsize			# largest string to read
	move	$a0 $gp	
	li	$v0, 8				# read string
	syscall

	move	$t0 $gp				# t0 to beginning of string
_instr_find_end:
	lb	$v0 0($gp)
	addiu	$gp $gp 1
	bnez	$v0 _instr_find_end

	# $gp points just after the null byte
	lb	$v0 0($t0)			# is first byte '\0'?
	bnez	$v0 _instr_noteof

	# we read nothing. Return '\n' (we don't have '\0'!!!)
	add	$v0 $zero 10			# load '\n' into $v0
	sb	$v0 -1($gp)
	sb	$zero 0($gp)			# terminate
	addiu	$gp $gp 1
	b	_instr_nonl

_instr_noteof:
	# Check if there really is a '\n'
	lb	$v0 -2($gp)
	bne	$v0 10 _instr_nonl

	# Write '\0' over '\n'
	sb	$zero -2($gp)			# Set end of string where '\n' was
	addiu	$gp $gp -1			# adjust for '\n'

_instr_nonl:
	lw	$a0 4($sp)			# get pointer to new str obj
	lw	$t1 str_size($a0)		# get pointer to int obj

	sub	$t0 $gp $a0
	subu	$t0 str_field			# calc actual str size
	addiu	$t0  -1				# adjust for '\0'
	sw	$t0 int_slot($t1)		# store string size in int obj
	addi	$gp $gp 3			# was already 1 past '\0'
	la	$t0 0xfffffffc
	and	$gp $gp $t0			# word align $gp

	sub	$t0 $gp $a0			# calc length
	srl	$t0 $t0 2			# divide by 4
	sw	$t0 obj_size($a0)		# set size field of obj

	lw	$ra 8($sp)			# restore return address
	addiu	$sp $sp 8
	jr	$ra				# return

#
#
# String.length
#		Returns Int Obj with string length of self
#
#	INPUT:	$a0 the string object
#	OUTPUT:	$a0 the int object which is the size of the string
#

	.globl	String.length
String.length:
	lw	$a0 str_size($a0)	# fetch attr
	jr	$ra	# Return

#
# String.concat
#
#   Concatenates arg1 onto the end of self and returns a pointer
#   to the new object.
#
#	INPUT:	$a0: the first string object (self)
#		Top of stack: the second string object (arg1)
#
#	OUTPUT:	$a0 the new string object
#

	.globl	String.concat
String.concat:

	addiu	$sp $sp -16
	sw	$ra 16($sp)			# save return address
	sw	$a0 12($sp)			# save self arg.
	sw	$0 8($sp)			# init GC area
	sw	$0 4($sp)			# init GC area

	jal	_MemMgr_Test			# test GC area

	lw	$a0 12($sp)
	lw	$a0 str_size($a0)
	jal     _quick_copy			# Call copy
	sw	$a0 8($sp)			# save new size object

	lw	$t1 20($sp)			# load arg object
	lw	$t1 str_size($t1)		# get size object
	lw	$t1 int_slot($t1)		# arg string size
	blez	$t1 _strcat_argempty		# nothing to add
	lw	$t0 12($sp)			# load self object
	lw	$t0 str_size($t0)		# get size object
	lw	$t0 int_slot($t0)		# self string size
	addu	$t0 $t0 $t1			# new size
	sw	$t0 int_slot($a0)		# store new size

	addiu	$a0 $t0 str_field		# size to allocate
	addiu	$a0 $a0 4			# include '\0', +3 to align
	la	$t2 0xfffffffc
	and	$a0 $a0 $t2			# align on word boundary
	addiu   $a0 $a0 1                       # make size odd for GC <-|
	sw	$a0 4($sp)			# save size in bytes     |
	addiu	$a0 $a0 3			# include eyecatcher(4) -1
	jal	_MemMgr_QAlloc			# check memory

	lw	$a0 12($sp)			# copy self
	jal	_quick_copy			# Call copy
	lw	$t0 8($sp)			# get the Int object
	sw	$t0 str_size($a0)		# store it in the str obj.

	sub	$t1 $gp $a0			# bytes allocated by _quick_copy
	lw	$t0 4($sp)			# get size in bytes (no eyecatcher)
	sub     $t0 $t0 1                       # Remove extra 1 (was for GC)
	sub	$t1 $t0 $t1			# more memory needed
	addu	$gp $gp $t1			# allocate rest
	srl	$t0 $t0 2			# convert to words
	sw	$t0 obj_size($a0)		# save new object size

	lw	$t0 12($sp)			# get original self object
	lw	$t0 str_size($t0)		# get size object
	lw	$t0 int_slot($t0)		# self string size
	addiu	$t1 $a0 str_field		# points to start of string data
	addu	$t1 $t1 $t0			# points to end: '\0'
	lw	$t0 20($sp)			# load arg object
	addiu	$t2 $t0 str_field		# points to start of arg data
	lw	$t0 str_size($t0)		# get arg size
	lw	$t0 int_slot($t0)
	addu	$t0 $t0 $t2			# find limit of copy

_strcat_copy:
	lb	$v0 0($t2)			# load from source
	sb	$v0 0($t1)			# save in destination
	addiu	$t2 $t2 1			# advance each index
	addiu	$t1 $t1 1
	bne	$t2 $t0 _strcat_copy		# check limit
	sb	$0 0($t1)			# add '\0'

	lw	$ra 16($sp)			# restore return address
	addiu	$sp $sp 20			# pop argument
	jr	$ra				# return

_strcat_argempty:
	lw	$a0 12($sp)			# load original self
	lw	$ra 16($sp)			# restore return address
	addiu	$sp $sp 20			# pop argument
	jr	$ra				# return

#
#
# String.substr(i,l)
#		Returns the sub string of self from i with length l
#		Offset starts at 0.
#
#	INPUT:	$a0 the string
#		length int object on top of stack (-4)
#		index int object below length on stack (-8)
#	OUTPUT:	The substring object in $a0
#

	.globl	String.substr
String.substr:
	addiu	$sp $sp -12		# frame
	sw	$ra 4($sp)		# save return
	sw	$a0 12($sp)		# save self
	sw	$0 8($sp)		# init GC area

	jal	_MemMgr_Test		# test GC area

	lw	$a0 12($sp)
	lw	$v0 obj_size($a0)
        la      $a0 Int_protObj		# ask if enough room to allocate
	lw	$a0 obj_size($a0)	#   a string object, an int object,
	add	$a0 $a0 $v0		#   and the string data
	addiu	$a0 $a0 2		# include 2 eyecatchers
	sll	$a0 $a0 2
	addi	$a0 $a0 str_maxsize
	jal	_MemMgr_QAlloc

_ss_ok:
	la	$a0 Int_protObj
	jal	_quick_copy
	jal	Int_init
	sw	$a0 8($sp)	# save new length obj
	la	$a0 String_protObj
	jal	_quick_copy
	jal	String_init	# new obj ptr in $a0
	move	$a2 $a0		# use a2 to make copy
	addiu	$gp $gp -4	# backup alloc ptr
	lw	$a1 12($sp)	# load orig
	lw	$t1 20($sp)	# index obj
	lw	$t2 16($sp)	# length obj
	lw	$t0 str_size($a1)
	lw	$v1 int_slot($t1) # index
	lw	$v0 int_slot($t0) # size of orig
	bltz	$v1 _ss_abort1	# index is smaller than 0
	bgt	$v1 $v0 _ss_abort2	# index > orig
	lw	$t3 int_slot($t2) # sub length
	add	$v1 $v1 $t3	# index+sublength
	bgt	$v1 $v0 _ss_abort3
	bltz	$t3 _ss_abort4
	lw	$t4 8($sp)	# load new length obj
	sw	$t3 int_slot($t4) # save new size
	sw	$t4 str_size($a0) # store size in string
	lw	$v1 int_slot($t1) # index
	addiu	$a1 $a1 str_field # advance src to str
	add	$a1 $a1 $v1	  # advance to indexed char
	addiu	$a2 $a2 str_field # advance dst to str
	beqz	$t3 _ss_end	  # empty length
_ss_loop:
	lb	$v0 0($a1)
	addiu	$a1 $a1 1	# inc src
	sb	$v0 0($a2)
	addiu	$a2 $a2 1	# inc dst
	addiu	$t3 $t3 -1	# dec ctr
	bnez	$t3 _ss_loop
_ss_end:
	sb	$zero 0($a2)	# null terminate
	move	$gp $a2
	addiu	$gp $gp 4	# realign the heap ptr
	la	$t0 0xfffffffc
	and	$gp $gp $t0	# word align $gp

	sub	$t0 $gp $a0	# calc object size
	srl	$t0 $t0 2	# div by 4
	sw	$t0 obj_size($a0)

	lw	$ra 4($sp)
	addiu	$sp $sp 20	# pop arguments
	jr	$ra

_ss_abort1:
	la	$a0 _sabort_msg1
	b	_ss_abort
_ss_abort2:
	la	$a0 _sabort_msg2
	b	_ss_abort
_ss_abort3:
	la	$a0 _sabort_msg3
	b	_ss_abort
_ss_abort4:
	la	$a0 _sabort_msg4
_ss_abort:
	li	$v0 4
	syscall
	la	$a0 _sabort_msg
	li	$v0 4
	syscall
	li	$v0 10		# exit
	syscall

#MEMORY MANAGER

	.globl _MemMgr_Init
_MemMgr_Init:
	addiu	$sp $sp -4
	sw	$ra 4($sp)			# save return address
	la	$t0 _MemMgr_INITIALIZER		# pointer to initialization
	lw	$t0 0($t0)
	jalr	$t0				# initialize
	lw	$ra 4($sp)			# restore return address
	addiu	$sp $sp 4
	jr	$ra				# return

#
# Memory Allocation


	.globl _MemMgr_Alloc
_MemMgr_Alloc:
	add	$gp $gp $a0			# attempt to allocate storage
	blt	$gp $s7 _MemMgr_Alloc_end	# check allocation
	sub	$gp $gp $a0			# restore $gp
	addiu	$sp $sp -4
	sw	$ra 4($sp)			# save return address
	move	$a1 $a0				# size
	addiu	$a0 $sp 4			# end of stack to collect
	la	$t0 _MemMgr_COLLECTOR		# pointer to collector function
	lw	$t0 0($t0)
	jalr	$t0				# garbage collect
	lw	$ra 4($sp)			# restore return address
	addiu	$sp $sp 4
	move	$a0 $a1				# put size into $a0
	add	$gp $gp $a0			# allocate storage
_MemMgr_Alloc_end:
	sub	$a0 $gp $a0
	jr	$ra				# return

#
# Query Memory Allocation
#


	.globl _MemMgr_QAlloc
_MemMgr_QAlloc:
	add	$t0 $gp $a0			# attempt to allocate storage
	blt	$t0 $s7 _MemMgr_QAlloc_end	# check allocation
	addiu	$sp $sp -4
	sw	$ra 4($sp)			# save return address
	move	$a1 $a0				# size
	addiu	$a0 $sp 4			# end of stack to collect
	la	$t0 _MemMgr_COLLECTOR		# pointer to collector function
	lw	$t0 0($t0)
	jalr	$t0				# garbage collect
	lw	$ra 4($sp)			# restore return address
	addiu	$sp $sp 4
	move	$a0 $a1				# put size into $a0
_MemMgr_QAlloc_end:
	jr	$ra				# return

#
# Test heap consistency


	.globl	_MemMgr_Test
_MemMgr_Test:
	la	$t0 _MemMgr_TEST		# Check if testing enabled
	lw	$t0 0($t0)
	beqz	$t0 _MemMgr_Test_end

# Allocate 0 bytes
	addiu	$sp $sp -4			# Save return address
	sw	$ra 4($sp)
	li	$a1 0				# size = 0
	addiu	$a0 $sp 4			# end of stack to collect
	la	$t0 _MemMgr_COLLECTOR		# pointer to collector function
	lw	$t0 0($t0)
	jalr	$t0				# garbage collect
	lw	$ra 4($sp)			# restore return address
	addiu	$sp $sp 4

_MemMgr_Test_end:
	jr	$ra


#
# Constants
#

#
# GenGC header offsets from "heap_start"
#

GenGC_HDRSIZE=44				# size of GenGC header
GenGC_HDRL0=0					# pointers to GenGC areas
GenGC_HDRL1=4
GenGC_HDRL2=8
GenGC_HDRL3=12
GenGC_HDRL4=16
GenGC_HDRMAJOR0=20				# history of major collections
GenGC_HDRMAJOR1=24
GenGC_HDRMINOR0=28				# history of minor collections
GenGC_HDRMINOR1=32
GenGC_HDRSTK=36					# start of stack
GenGC_HDRREG=40					# current REG mask



GenGC_HEAPEXPGRAN=14				



GenGC_OLDRATIO=2				



GenGC_ARU_MASK=0xC37F0000



	.globl _GenGC_Init
_GenGC_Init:
	la	$t0 heap_start
	addiu	$t1 $t0 GenGC_HDRSIZE
	sw	$t1 GenGC_HDRL0($t0)		# save start of old area
	sw	$t1 GenGC_HDRL1($t0)		# save start of reserve area
	sub	$t1 $a2 $t1			# find reserve/work area barrier
	srl	$t1 $t1 1
	la	$v0 0xfffffffc
	and	$t1 $t1 $v0
	blez	$t1 _GenGC_Init_error		# heap initially to small
	sub	$gp $a2 $t1
	sw	$gp GenGC_HDRL2($t0)		# save start of work area	
	sw	$a2 GenGC_HDRL3($t0)		# save end of work area
	move	$s7 $a2				# set limit pointer
	sw	$0 GenGC_HDRMAJOR0($t0)		# clear histories
	sw	$0 GenGC_HDRMAJOR1($t0)
	sw	$0 GenGC_HDRMINOR0($t0)
	sw	$0 GenGC_HDRMINOR1($t0)
	sw	$a0 GenGC_HDRSTK($t0)		# save stack start
	sw	$a1 GenGC_HDRREG($t0)		# save register mask
	li	$v0 9				# get heap end
	move	$a0 $zero
	syscall					# sbrk
	sw	$v0 GenGC_HDRL4($t0)		# save heap limit
	jr	$ra				# return
_GenGC_Init_error:
	la	$a0 _GenGC_INITERROR		# show error message
	li	$v0 4
	syscall
	li	$v0 10				# exit
	syscall

#
# Record Assignment


	.globl _GenGC_Assign
_GenGC_Assign:
	addiu	$s7 $s7 -4
	sw	$a1 0($s7)			# save pointer to assignment
	bgt	$s7 $gp _GenGC_Assign_done
	addiu	$sp $sp -8
	sw	$ra 8($sp)			# save return address
	sw	$a0 4($sp)			# sm: save $a0
	move    $a1 $0				# size
	addiu	$a0 $sp 0			# end of stack to collect
	sw      $0 0($sp)                       # play it safe with off-by-1
	jal	_GenGC_Collect
	lw	$ra 8($sp)			# restore return address
	lw	$a0 4($sp)			# restore $a0
	addiu	$sp $sp 8
_GenGC_Assign_done:
	jr	$ra				# return

	.globl	_gc_check
_gc_check:
	beqz	$a1, _gc_ok			# void is ok
	lw	$a2 obj_eyecatch($a1)		# and check if it is valid
	addiu	$a2 $a2 1
	bnez	$a2 _gc_abort
_gc_ok:
	jr	$ra

_gc_abort:		 
	la      $a0 _gc_abort_msg
	li	$v0 4
	syscall                  # print gc message
	li   	$v0 10
        syscall			 # exit




	.globl _GenGC_Collect
_GenGC_Collect:
	addiu	$sp $sp -12
	sw	$ra 12($sp)			# save return address
	sw	$a0 8($sp)			# save stack end
	sw	$a1 4($sp)			# save size
	la	$a0 _GenGC_COLLECT		# print collection message
	li	$v0 4
	syscall
	lw	$a0 8($sp)			# restore stack end
	jal	_GenGC_MinorC			# minor collection
	la	$a1 heap_start
	lw	$t1 GenGC_HDRMINOR1($a1)
	addu	$t1 $t1 $a0
	srl	$t1 $t1 1
	sw	$t1 GenGC_HDRMINOR1($a1)	# update histories
	sw	$a0 GenGC_HDRMINOR0($a1)
	move	$t0 $t1				# set $t0 to max of minor
	bgt	$t1 $a0 _GenGC_Collect_maxmaj
	move	$t0 $a0
_GenGC_Collect_maxmaj:
	lw	$t1 GenGC_HDRMAJOR0($a1)	# set $t1 to max of major
	lw	$t2 GenGC_HDRMAJOR1($a1)
	bgt	$t1 $t2 _GenGC_Collect_maxdef
	move	$t1 $t2
_GenGC_Collect_maxdef:
	lw	$t2 GenGC_HDRL3($a1)
	sub	$t0 $t2 $t0			# set $t0 to L3-$t0-$t1
	sub	$t0 $t0 $t1
	lw	$t1 GenGC_HDRL0($a1)		# set $t1 to L3-(L3-L0)/2
	sub	$t1 $t2 $t1
	srl	$t1 $t1 1
	sub	$t1 $t2 $t1
	blt	$t0 $t1 _GenGC_Collect_breakpt	# set $t0 to minimum of above
	move	$t0 $t1
_GenGC_Collect_breakpt:
	lw	$t1 GenGC_HDRL1($a1)		# get end of old area
	bge	$t1 $t0 _GenGC_Collect_major
	lw	$t0 GenGC_HDRL2($a1)
	lw	$t1 GenGC_HDRL3($a1)
	lw	$t2 4($sp)			# load requested size into $t2
	sub	$t0 $t1 $t0			# find reserve/work area barrier
	srl	$t0 $t0 1
	la	$t3 0xfffffffc
	and	$t0 $t0 $t3
	sub	$t0 $t1 $t0			# reserve/work barrier
	addu	$t2 $t0 $t2			# test allocation
	bge	$t2 $t1 _GenGC_Collect_major	# check if work area too small
_GenGC_Collect_nomajor:
	lw	$t1 GenGC_HDRL2($a1)
	sw	$t1 GenGC_HDRL1($a1)		# expand old area
	sw	$t0 GenGC_HDRL2($a1)		# set new reserve/work barrier
	move	$gp $t0				# set $gp
	lw	$s7 GenGC_HDRL3($a1)		# load limit into $s7
	b	_GenGC_Collect_done
_GenGC_Collect_major:
	la	$a0 _GenGC_Major		# print collection message
	li	$v0 4
	syscall
	lw	$a0 8($sp)			# restore stack end
	jal	_GenGC_MajorC			# major collection
	la	$a1 heap_start
	lw	$t1 GenGC_HDRMAJOR1($a1)
	addu	$t1 $t1 $a0
	srl	$t1 $t1 1
	sw	$t1 GenGC_HDRMAJOR1($a1)	# update histories
	sw	$a0 GenGC_HDRMAJOR0($a1)
	lw	$t1 GenGC_HDRL3($a1)		# find ratio of the old area
	lw	$t0 GenGC_HDRL0($a1)
	sub	$t1 $t1 $t0
	srl	$t1 $t1 GenGC_OLDRATIO
	addu	$t1 $t0 $t1
	lw	$t0 GenGC_HDRL1($a1)
	sub	$t0 $t0 $t1
	sll	$t0 $t0 GenGC_OLDRATIO		# amount to expand in $t0
	lw	$t1 GenGC_HDRL3($a1)		# load L3
	lw	$t2 GenGC_HDRL1($a1)		# load L1
	sub	$t2 $t1 $t2
	srl	$t2 $t2 1
	la	$t3 0xfffffffc
	and	$t2 $t2 $t3
	sub	$t1 $t1 $t2			# reserve/work barrier
	lw	$t2 4($sp)			# restore size
	addu	$t1 $t1 $t2
	lw	$t2 GenGC_HDRL3($a1)		# load L3
	sub	$t1 $t1 $t2			# test allocation
	addiu	$t1 $t1 4			# adjust for round off errors
	sll	$t1 $t1 1			# need to allocate $t1 memory
	blt	$t1 $t0 _GenGC_Collect_enough	# put max of $t0, $t1 in $t0
	move	$t0 $t1
_GenGC_Collect_enough:
	blez	$t0 _GenGC_Collect_setL2	# no need to expand
	addiu	$t1 $0 1			# put 1 in $t1
	sll	$t1 $t1 GenGC_HEAPEXPGRAN	# get granularity of expansion
	addiu	$t1 $t1 -1			# align to granularity
	addu	$t0 $t0 $t1
	nor	$t1 $t1 $t1
	and	$t0 $t0 $t1			# total memory needed
	lw	$t1 GenGC_HDRL3($a1)		# load L3
	lw	$t2 GenGC_HDRL4($a1)		# load L4
	sub	$t1 $t2 $t1
	sub	$t2 $t0 $t1			# actual amount to allocate
	bgtz	$t2 _GenGC_Collect_getmem	# check if really need to allocate
_GenGC_Collect_xfermem:
	lw	$s7 GenGC_HDRL3($a1)		# load L3
	addu	$s7 $s7 $t0			# expand by $t0, set $s7
	sw	$s7 GenGC_HDRL3($a1)		# save L3
	b	_GenGC_Collect_findL2
_GenGC_Collect_getmem:
	li	$v0 9				# sbrk
	move	$a0 $t2				# set the size to expand the heap
	syscall
	li	$v0 9
	move	$a0 $zero
	syscall					# get new end of heap in $v0
	sw	$v0 GenGC_HDRL4($a1)		# save L4
	sw	$v0 GenGC_HDRL3($a1)		# save L3
	move	$s7 $v0				# set $s7
	b	_GenGC_Collect_findL2
_GenGC_Collect_setL2:
	lw	$s7 GenGC_HDRL3($a1)		# load L3
_GenGC_Collect_findL2:
	lw	$t1 GenGC_HDRL1($a1)		# load L1
	sub	$t1 $s7 $t1
	srl	$t1 $t1 1
	la	$t0 0xfffffffc
	and	$t1 $t1 $t0
	sub	$gp $s7 $t1			# reserve/work barrier
	sw	$gp GenGC_HDRL2($a1)		# save L2
_GenGC_Collect_done:

# Clear new generation to catch missing pointers
	move	$t0 $gp
_GenGC_Clear_loop:
	sw	$zero 0($t0)
	addiu	$t0 $t0 4
	blt	$t0 $s7 _GenGC_Clear_loop

	lw	$a1 4($sp)			# restore size
	lw	$ra 12($sp)			# restore return address
	addiu	$sp $sp 12
	jr	$ra				# return

#

#

	.globl _GenGC_ChkCopy
_GenGC_ChkCopy:
	blt	$a0 $a1 _GenGC_ChkCopy_done	# check bounds
	bge	$a0 $a2 _GenGC_ChkCopy_done
	andi	$t2 $a0 1			# check if odd
	bnez	$t2 _GenGC_ChkCopy_done
	addiu	$t2 $0 -1
	lw	$t1 obj_eyecatch($a0)		# check eyecatcher
	bne	$t2 $t1 _gc_abort
	lw	$t1 obj_tag($a0)		# check object tag
	beq	$t2 $t1 _GenGC_ChkCopy_done
	lw	$t1 obj_size($a0)		# get size of object
	beqz	$t1 _GenGC_ChkCopy_forward	# if size = 0, get forwarding pointer
	move	$t0 $a0				# save pointer to old object in $t0
	addiu	$gp $gp 4			# allocate memory for eyecatcher
	move	$a0 $gp				# get address of new object
	sw	$t2 obj_eyecatch($a0)		# save eye catcher
	sll	$t1 $t1 2			# convert words to bytes
	addu	$t1 $t0 $t1			# set $t1 to limit of copy
	move	$t2 $t0				# set $t2 to old object
_GenGC_ChkCopy_loop:
	lw	$v0 0($t0)			# copy
	sw	$v0 0($gp)
	addiu	$t0 $t0 4			# update each index
	addiu	$gp $gp 4
	bne	$t0 $t1 _GenGC_ChkCopy_loop	# check for limit of copy
	sw	$0 obj_size($t2)		# set size to 0
	sw	$a0 obj_disp($t2)		# save forwarding pointer
_GenGC_ChkCopy_done:
	jr	$ra				# return
_GenGC_ChkCopy_forward:
	lw	$a0 obj_disp($a0)		# get forwarding pointer
	jr	$ra				# return



	.globl _GenGC_MinorC
_GenGC_MinorC:
	addiu	$sp $sp -20
	sw	$ra 20($sp)			# save return address
	la	$t0 heap_start
	lw	$a1 GenGC_HDRL2($t0)		# set lower bound to work area
	move	$a2 $s7				# set upper bound for ChkCopy
	lw	$gp GenGC_HDRL1($t0)		# set $gp into reserve area
	sw	$a0 16($sp)			# save stack end
	lw	$t0 GenGC_HDRSTK($t0)		# set $t0 to stack start
	move	$t1 $a0				# set $t1 to stack end
	ble	$t0 $t1 _GenGC_MinorC_stackend	# check for empty stack
_GenGC_MinorC_stackloop: 			# $t1 stack end, $t0 index
	addiu	$t0 $t0 -4			# update index
	sw	$t0 12($sp)			# save stack index
	lw	$a0 4($t0)			# get stack item
	jal	_GenGC_ChkCopy			# check and copy
	lw	$t0 12($sp)			# load stack index
	sw	$a0 4($t0)
	lw	$t1 16($sp)			# restore stack end
	bgt	$t0 $t1 _GenGC_MinorC_stackloop	# loop
_GenGC_MinorC_stackend:
	la	$t0 heap_start
	lw	$t0 GenGC_HDRREG($t0)		# get Register mask
	sw	$t0 16($sp)			# save Register mask
_GenGC_MinorC_reg16:
	srl	$t0 $t0 16			# shift to proper bit
	andi	$t1 $t0 1
	beq	$t1 $0 _GenGC_MinorC_reg17	# check if set
	move	$a0 $16				# set test pointer
	jal	_GenGC_ChkCopy			# check and copy
	move	$16 $a0				# update register
_GenGC_MinorC_reg17:
	lw	$t0 16($sp)			# restore mask
	srl	$t0 $t0 17			# shift to proper bit
	andi	$t1 $t0 1
	beq	$t1 $0 _GenGC_MinorC_reg18	# check if set
	move	$a0 $17				# set test pointer
	jal	_GenGC_ChkCopy			# check and copy
	move	$17 $a0				# update register
_GenGC_MinorC_reg18:
	lw	$t0 16($sp)			# restore mask
	srl	$t0 $t0 18			# shift to proper bit
	andi	$t1 $t0 1
	beq	$t1 $0 _GenGC_MinorC_reg19	# check if set
	move	$a0 $18				# set test pointer
	jal	_GenGC_ChkCopy			# check and copy
	move	$18 $a0				# update register
_GenGC_MinorC_reg19:
	lw	$t0 16($sp)			# restore mask
	srl	$t0 $t0 19			# shift to proper bit
	andi	$t1 $t0 1
	beq	$t1 $0 _GenGC_MinorC_reg20	# check if set
	move	$a0 $19				# set test pointer
	jal	_GenGC_ChkCopy			# check and copy
	move	$19 $a0				# update register
_GenGC_MinorC_reg20:
	lw	$t0 16($sp)			# restore mask
	srl	$t0 $t0 20			# shift to proper bit
	andi	$t1 $t0 1
	beq	$t1 $0 _GenGC_MinorC_reg21	# check if set
	move	$a0 $20				# set test pointer
	jal	_GenGC_ChkCopy			# check and copy
	move	$20 $a0				# update register
_GenGC_MinorC_reg21:
	lw	$t0 16($sp)			# restore mask
	srl	$t0 $t0 21			# shift to proper bit
	andi	$t1 $t0 1
	beq	$t1 $0 _GenGC_MinorC_reg22	# check if set
	move	$a0 $21				# set test pointer
	jal	_GenGC_ChkCopy			# check and copy
	move	$21 $a0				# update register
_GenGC_MinorC_reg22:
	lw	$t0 16($sp)			# restore mask
	srl	$t0 $t0 22			# shift to proper bit
	andi	$t1 $t0 1
	beq	$t1 $0 _GenGC_MinorC_reg24	# check if set
	move	$a0 $22				# set test pointer
	jal	_GenGC_ChkCopy			# check and copy
	move	$22 $a0				# update register
_GenGC_MinorC_reg24:
	lw	$t0 16($sp)			# restore mask
	srl	$t0 $t0 24			# shift to proper bit
	andi	$t1 $t0 1
	beq	$t1 $0 _GenGC_MinorC_reg25	# check if set
	move	$a0 $24				# set test pointer
	jal	_GenGC_ChkCopy			# check and copy
	move	$24 $a0				# update register
_GenGC_MinorC_reg25:
	lw	$t0 16($sp)			# restore mask
	srl	$t0 $t0 25			# shift to proper bit
	andi	$t1 $t0 1
	beq	$t1 $0 _GenGC_MinorC_reg30	# check if set
	move	$a0 $25				# set test pointer
	jal	_GenGC_ChkCopy			# check and copy
	move	$25 $a0				# update register
_GenGC_MinorC_reg30:
	lw	$t0 16($sp)			# restore mask
	srl	$t0 $t0 30			# shift to proper bit
	andi	$t1 $t0 1
	beq	$t1 $0 _GenGC_MinorC_reg31	# check if set
	move	$a0 $30				# set test pointer
	jal	_GenGC_ChkCopy			# check and copy
	move	$30 $a0				# update register
_GenGC_MinorC_reg31:
	lw	$t0 16($sp)			# restore mask
	srl	$t0 $t0 31			# shift to proper bit
	andi	$t1 $t0 1
	beq	$t1 $0 _GenGC_MinorC_regend	# check if set
	move	$a0 $31				# set test pointer
	jal	_GenGC_ChkCopy			# check and copy
	move	$31 $a0				# update register
_GenGC_MinorC_regend:
	la	$t0 heap_start
	lw	$t3 GenGC_HDRL0($t0)		# lower limit of old area
	lw	$t4 GenGC_HDRL1($t0)		# upper limit of old area
	lw	$t0 GenGC_HDRL3($t0)		# get L3
	sw	$t0 16($sp)			# save index limit
	bge	$s7 $t0 _GenGC_MinorC_assnend	# check for no assignments
_GenGC_MinorC_assnloop:				# $s7 index, $t0 limit
	lw	$a0 0($s7)			# get table entry
	blt	$a0 $t3 _GenGC_MinorC_assnnext	# must point into old area
	bge	$a0 $t4 _GenGC_MinorC_assnnext
	lw	$a0 0($a0)			# get pointer to check
	jal	_GenGC_ChkCopy			# check and copy
	lw	$t0 0($s7)
	sw	$a0 0($t0)			# update pointer
	lw	$t0 16($sp)			# restore index limit
_GenGC_MinorC_assnnext:
	addiu	$s7 $s7 4			# update index
	blt	$s7 $t0 _GenGC_MinorC_assnloop	# loop
_GenGC_MinorC_assnend:
	la	$t0 heap_start
	lw	$t0 GenGC_HDRL1($t0)		# start of reserve area
	bge	$t0 $gp _GenGC_MinorC_heapend	# check for no objects
_GenGC_MinorC_heaploop:				# $t0: index, $gp: limit
	addiu	$t0 $t0 4			# skip over eyecatcher
	addiu	$t1 $0 -1			# check for eyecatcher
	lw	$t2 obj_eyecatch($t0)
	bne	$t1 $t2 _GenGC_MinorC_error	# eyecatcher not found
	lw	$a0 obj_size($t0)		# get object size
	sll	$a0 $a0 2			# words to bytes
	lw	$t1 obj_tag($t0)		# get the object's tag
	lw	$t2 _int_tag			# test for int object
	beq	$t1 $t2 _GenGC_MinorC_int
	lw	$t2 _bool_tag			# test for bool object
	beq	$t1 $t2 _GenGC_MinorC_bool
	lw	$t2 _string_tag			# test for string object
	beq	$t1 $t2 _GenGC_MinorC_string
_GenGC_MinorC_other:
	addi	$t1 $t0 obj_attr		# start at first attribute
	add	$t2 $t0 $a0			# limit of attributes
	bge	$t1 $t2 _GenGC_MinorC_nextobj	# check for no attributes
	sw	$t0 16($sp)			# save pointer to object
	sw	$a0 12($sp)			# save object size
	sw	$t2 4($sp)			# save limit
_GenGC_MinorC_objloop:				# $t1: index, $t2: limit
	sw	$t1 8($sp)			# save index
	lw	$a0 0($t1)			# set pointer to check
	jal	_GenGC_ChkCopy			# check and copy
	lw	$t1 8($sp)			# restore index
	sw	$a0 0($t1)			# update object pointer
	lw	$t2 4($sp)			# restore limit
	addiu	$t1 $t1 4
	blt	$t1 $t2 _GenGC_MinorC_objloop	# loop
_GenGC_MinorC_objend:
	lw	$t0 16($sp)			# restore pointer to object
	lw	$a0 12($sp)			# restore object size
	b	_GenGC_MinorC_nextobj		# next object
_GenGC_MinorC_string:
	sw	$t0 16($sp)			# save pointer to object
	sw	$a0 12($sp)			# save object size
	lw	$a0 str_size($t0)		# set test pointer
	jal	_GenGC_ChkCopy			# check and copy
	lw	$t0 16($sp)			# restore pointer to object
	sw	$a0 str_size($t0)		# update size pointer
	lw	$a0 12($sp)			# restore object size
_GenGC_MinorC_int:
_GenGC_MinorC_bool:
_GenGC_MinorC_nextobj:
	add	$t0 $t0 $a0			# find next object
	blt	$t0 $gp _GenGC_MinorC_heaploop	# loop
_GenGC_MinorC_heapend:
	la	$t0 heap_start
	sw	$gp GenGC_HDRL2($t0)		# set L2 to $gp
	lw	$a0 GenGC_HDRL1($t0)
	sub	$a0 $gp $a0			# find size after collection
	lw	$ra 20($sp)			# restore return address
	addiu	$sp $sp 20
	jr	$ra				# return
_GenGC_MinorC_error:
	la	$a0 _GenGC_MINORERROR		# show error message
	li	$v0 4
	syscall
	li	$v0 10				# exit
	syscall



	.globl _GenGC_OfsCopy
_GenGC_OfsCopy:
	blt	$a0 $a1 _GenGC_OfsCopy_done	# check lower bound
	bge	$a0 $v1 _GenGC_OfsCopy_done	# check upper bound
	andi	$t2 $a0 1			# check if odd
	bnez	$t2 _GenGC_OfsCopy_done
	addiu	$t2 $0 -1
	lw	$t1 obj_eyecatch($a0)		# check eyecatcher
	bne	$t2 $t1 _gc_abort
	lw	$t1 obj_tag($a0)		# check object tag
	beq	$t2 $t1 _GenGC_OfsCopy_done
	blt	$a0 $a2 _GenGC_OfsCopy_old	# check if old, X object
	sub	$v0 $a1 $a2			# compute offset
	add	$a0 $a0 $v0			# apply pointer offset
	jr	$ra				# return
_GenGC_OfsCopy_old:
	lw	$t1 obj_size($a0)		# get size of object
	sll	$t1 $t1 2			# convert words to bytes
	beqz	$t1 _GenGC_OfsCopy_forward	# if size = 0, get forwarding pointer
	move	$t0 $a0				# save pointer to old object in $t0
	addu	$v0 $gp $t1			# test allocation
	addiu	$v0 $v0 4
	blt	$v0 $s7 _GenGC_OfsCopy_memok	# check if enoguh room for object
	sub	$a0 $v0 $s7			# amount to expand minus 1
	addiu	$v0 $0 1
	sll	$v0 $v0 GenGC_HEAPEXPGRAN
	add	$a0 $a0 $v0
	addiu	$v0 $v0 -1
	nor	$v0 $v0 $v0			# get grain mask
	and	$a0 $a0 $v0			# align to grain size
	li	$v0 9
	syscall					# expand heap
	li	$v0 9
	move	$a0 $0
	syscall					# get end of heap in $v0
	move	$s7 $v0				# save heap end in $s7
	move	$a0 $t0				# restore pointer to old object in $a0
_GenGC_OfsCopy_memok:
	addiu	$gp $gp 4			# allocate memory for eyecatcher
	move	$a0 $gp				# get address of new object
	sw	$t2 obj_eyecatch($a0)		# save eye catcher
	addu	$t1 $t0 $t1			# set $t1 to limit of copy
	move	$t2 $t0				# set $t2 to old object
_GenGC_OfsCopy_loop:
	lw	$v0 0($t0)			# copy
	sw	$v0 0($gp)
	addiu	$t0 $t0 4			# update each index
	addiu	$gp $gp 4
	bne	$t0 $t1 _GenGC_OfsCopy_loop	# check for limit of copy
	sw	$0 obj_size($t2)		# set size to 0
	sub	$v0 $a1 $a2			# compute offset
	add	$a0 $a0 $v0			# apply pointer offset
	sw	$a0 obj_disp($t2)		# save forwarding pointer
_GenGC_OfsCopy_done:
	jr	$ra				# return
_GenGC_OfsCopy_forward:
	lw	$a0 obj_disp($a0)		# get forwarding pointer
	jr	$ra				# return



	.globl _GenGC_MajorC
_GenGC_MajorC:
	addiu	$sp $sp -20
	sw	$ra 20($sp)			# save return address
	la	$t0 heap_start
	lw	$s7 GenGC_HDRL4($t0)		# limit pointer for collection
	lw	$gp GenGC_HDRL2($t0)		# allocation pointer for collection
	lw	$a1 GenGC_HDRL0($t0)		# set inputs for OfsCopy
	lw	$a2 GenGC_HDRL1($t0)
	lw	$v1 GenGC_HDRL2($t0)
	sw	$a0 16($sp)			# save stack end
	lw	$t0 GenGC_HDRSTK($t0)		# set $t0 to stack start
	move	$t1 $a0				# set $t1 to stack end
	ble	$t0 $t1 _GenGC_MajorC_stackend	# check for empty stack
_GenGC_MajorC_stackloop: 			# $t1 stack end, $t0 index
	addiu	$t0 $t0 -4			# update index
	sw	$t0 12($sp)			# save stack index
	lw	$a0 4($t0)			# get stack item
	jal	_GenGC_OfsCopy			# check and copy
	lw	$t0 12($sp)			# load stack index
	sw	$a0 4($t0)
	lw	$t1 16($sp)			# restore stack end
	bgt	$t0 $t1 _GenGC_MajorC_stackloop	# loop
_GenGC_MajorC_stackend:
	la	$t0 heap_start
	lw	$t0 GenGC_HDRREG($t0)		# get Register mask
	sw	$t0 16($sp)			# save Register mask
_GenGC_MajorC_reg16:
	srl	$t0 $t0 16			# shift to proper bit
	andi	$t1 $t0 1
	beq	$t1 $0 _GenGC_MajorC_reg17	# check if set
	move	$a0 $16				# set test pointer
	jal	_GenGC_OfsCopy			# check and copy
	move	$16 $a0				# update register
_GenGC_MajorC_reg17:
	lw	$t0 16($sp)			# restore mask
	srl	$t0 $t0 17			# shift to proper bit
	andi	$t1 $t0 1
	beq	$t1 $0 _GenGC_MajorC_reg18	# check if set
	move	$a0 $17				# set test pointer
	jal	_GenGC_OfsCopy			# check and copy
	move	$17 $a0				# update register
_GenGC_MajorC_reg18:
	lw	$t0 16($sp)			# restore mask
	srl	$t0 $t0 18			# shift to proper bit
	andi	$t1 $t0 1
	beq	$t1 $0 _GenGC_MajorC_reg19	# check if set
	move	$a0 $18				# set test pointer
	jal	_GenGC_OfsCopy			# check and copy
	move	$18 $a0				# update register
_GenGC_MajorC_reg19:
	lw	$t0 16($sp)			# restore mask
	srl	$t0 $t0 19			# shift to proper bit
	andi	$t1 $t0 1
	beq	$t1 $0 _GenGC_MajorC_reg20	# check if set
	move	$a0 $19				# set test pointer
	jal	_GenGC_OfsCopy			# check and copy
	move	$19 $a0				# update register
_GenGC_MajorC_reg20:
	lw	$t0 16($sp)			# restore mask
	srl	$t0 $t0 20			# shift to proper bit
	andi	$t1 $t0 1
	beq	$t1 $0 _GenGC_MajorC_reg21	# check if set
	move	$a0 $20				# set test pointer
	jal	_GenGC_OfsCopy			# check and copy
	move	$20 $a0				# update register
_GenGC_MajorC_reg21:
	lw	$t0 16($sp)			# restore mask
	srl	$t0 $t0 21			# shift to proper bit
	andi	$t1 $t0 1
	beq	$t1 $0 _GenGC_MajorC_reg22	# check if set
	move	$a0 $21				# set test pointer
	jal	_GenGC_OfsCopy			# check and copy
	move	$21 $a0				# update register
_GenGC_MajorC_reg22:
	lw	$t0 16($sp)			# restore mask
	srl	$t0 $t0 22			# shift to proper bit
	andi	$t1 $t0 1
	beq	$t1 $0 _GenGC_MajorC_reg24	# check if set
	move	$a0 $22				# set test pointer
	jal	_GenGC_OfsCopy			# check and copy
	move	$22 $a0				# update register
_GenGC_MajorC_reg24:
	lw	$t0 16($sp)			# restore mask
	srl	$t0 $t0 24			# shift to proper bit
	andi	$t1 $t0 1
	beq	$t1 $0 _GenGC_MajorC_reg25	# check if set
	move	$a0 $24				# set test pointer
	jal	_GenGC_OfsCopy			# check and copy
	move	$24 $a0				# update register
_GenGC_MajorC_reg25:
	lw	$t0 16($sp)			# restore mask
	srl	$t0 $t0 25			# shift to proper bit
	andi	$t1 $t0 1
	beq	$t1 $0 _GenGC_MajorC_reg30	# check if set
	move	$a0 $25				# set test pointer
	jal	_GenGC_OfsCopy			# check and copy
	move	$25 $a0				# update register
_GenGC_MajorC_reg30:
	lw	$t0 16($sp)			# restore mask
	srl	$t0 $t0 30			# shift to proper bit
	andi	$t1 $t0 1
	beq	$t1 $0 _GenGC_MajorC_reg31	# check if set
	move	$a0 $30				# set test pointer
	jal	_GenGC_OfsCopy			# check and copy
	move	$30 $a0				# update register
_GenGC_MajorC_reg31:
	lw	$t0 16($sp)			# restore mask
	srl	$t0 $t0 31			# shift to proper bit
	andi	$t1 $t0 1
	beq	$t1 $0 _GenGC_MajorC_regend	# check if set
	move	$a0 $31				# set test pointer
	jal	_GenGC_OfsCopy			# check and copy
	move	$31 $a0				# update register
_GenGC_MajorC_regend:
	la	$t0 heap_start
	lw	$t0 GenGC_HDRL1($t0)		# start of X area
	bge	$t0 $gp _GenGC_MajorC_heapend	# check for no objects
_GenGC_MajorC_heaploop:				# $t0: index, $gp: limit
	addiu	$t0 $t0 4			# skip over eyecatcher
	addiu	$t1 $0 -1			# check for eyecatcher
	lw	$t2 obj_eyecatch($t0)
	bne	$t1 $t2 _GenGC_MajorC_error	# eyecatcher not found
	lw	$a0 obj_size($t0)		# get object size
	sll	$a0 $a0 2			# words to bytes
	lw	$t1 obj_tag($t0)		# get the object's tag
	lw	$t2 _int_tag			# test for int object
	beq	$t1 $t2 _GenGC_MajorC_int
	lw	$t2 _bool_tag			# test for bool object
	beq	$t1 $t2 _GenGC_MajorC_bool
	lw	$t2 _string_tag			# test for string object
	beq	$t1 $t2 _GenGC_MajorC_string
_GenGC_MajorC_other:
	addi	$t1 $t0 obj_attr		# start at first attribute
	add	$t2 $t0 $a0			# limit of attributes
	bge	$t1 $t2 _GenGC_MajorC_nextobj	# check for no attributes
	sw	$t0 16($sp)			# save pointer to object
	sw	$a0 12($sp)			# save object size
	sw	$t2 4($sp)			# save limit
_GenGC_MajorC_objloop:				# $t1: index, $t2: limit
	sw	$t1 8($sp)			# save index
	lw	$a0 0($t1)			# set pointer to check
	jal	_GenGC_OfsCopy			# check and copy
	lw	$t1 8($sp)			# restore index
	sw	$a0 0($t1)			# update object pointer
	lw	$t2 4($sp)			# restore limit
	addiu	$t1 $t1 4
	blt	$t1 $t2 _GenGC_MajorC_objloop	# loop
_GenGC_MajorC_objend:
	lw	$t0 16($sp)			# restore pointer to object
	lw	$a0 12($sp)			# restore object size
	b	_GenGC_MajorC_nextobj		# next object
_GenGC_MajorC_string:
	sw	$t0 16($sp)			# save pointer to object
	sw	$a0 12($sp)			# save object size
	lw	$a0 str_size($t0)		# set test pointer
	jal	_GenGC_OfsCopy			# check and copy
	lw	$t0 16($sp)			# restore pointer to object
	sw	$a0 str_size($t0)		# update size pointer
	lw	$a0 12($sp)			# restore object size
_GenGC_MajorC_int:
_GenGC_MajorC_bool:
_GenGC_MajorC_nextobj:
	add	$t0 $t0 $a0			# find next object
	blt	$t0 $gp _GenGC_MajorC_heaploop	# loop
_GenGC_MajorC_heapend:
	la	$t0 heap_start
	lw	$a0 GenGC_HDRL2($t0)		# get end of collection
	sub	$a0 $gp $a0			# get length after collection
	lw	$t1 GenGC_HDRL0($t0)		# get L0
	lw	$t2 GenGC_HDRL1($t0)		# get L1
	bge	$t2 $gp _GenGC_MajorC_bcpyend	# test for empty copy
_GenGC_MajorC_bcpyloop:				# $t2 index, $gp limit, $t1 dest
	lw	$v0 0($t2)			# copy
	sw	$v0 0($t1)
	addiu	$t2 $t2 4			# update each index
	addiu	$t1 $t1 4
	bne	$t2 $gp _GenGC_MajorC_bcpyloop	# loop
_GenGC_MajorC_bcpyend:
	sw	$s7 GenGC_HDRL4($t0)		# save end of heap
	lw	$t1 GenGC_HDRL0($t0)		# get L0
	lw	$t2 GenGC_HDRL1($t0)		# get L1
	sub	$t1 $t2 $t1			# find offset of block copy
	sub	$gp $gp $t1			# find end of old area
	sw	$gp GenGC_HDRL1($t0)		# save end of old area
	lw	$ra 20($sp)			# restore return address
	addiu	$sp $sp 20
	jr	$ra				# return
_GenGC_MajorC_error:
	la	$a0 _GenGC_MAJORERROR		# show error message
	li	$v0 4
	syscall
	li	$v0 10				# exit
	syscall



	.globl	_GenGC_SetRegMask
_GenGC_SetRegMask:
	li	$t0 GenGC_ARU_MASK		# apply Automatic Register Mask (ARU)
	and	$a0 $a0 $t0
	la	$t0 heap_start			# set $t0 to the start of the heap
	sw	$a0 GenGC_HDRREG($t0)		# save the Register mask
	jr	$ra				# return


	.globl	_GenGC_QRegMask
_GenGC_QRegMask:
	la	$a0 heap_start			# set $a0 to the start of the heap
	lw	$a0 GenGC_HDRREG($a0)		# get the Register mask
	jr	$ra				# return




NoGC_EXPANDSIZE=0x10000				# size to expand heap


	.globl _NoGC_Init
_NoGC_Init:
	la	$gp heap_start			# set $gp to the start of the heap
	li	$v0 9				# get heap end
	move	$a0 $zero
	syscall					# sbrk
	move	$s7 $v0				# set limit pointer
	jr	$ra



	.globl _NoGC_Collect
_NoGC_Collect:
	la	$a0 _NoGC_COLLECT		# show collection message
	li	$v0 4
	syscall
_NoGC_Collect_loop:
	add	$t0 $gp $a1			# test allocation
	blt	$t0 $s7 _NoGC_Collect_ok	# stop if enough
	li	$v0 9				# expand heap
	li	$a0 NoGC_EXPANDSIZE		# set the size to expand the heap
	syscall					# sbrk
	li	$v0 9				# get heap end
	move	$a0 $zero
	syscall					# sbrk
	move	$s7 $v0				# set limit pointer
	b	_NoGC_Collect_loop		# loop
_NoGC_Collect_ok:
	jr	$ra				# return

