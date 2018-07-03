
class BinaryTree inherits Tree{
	leftchild: BinaryTree;
	rightchild: BinaryTree;
	printValue():Object{
		io.out_int(self.getNode().getValue())
		--io.out_int(listChilds(0).getValue())
	};
	init(value: Int, listChilds: ListTree): BinaryTree{
	{
		if listChilds.count()<2 then
		    self.init2(value,listChilds.getChild(0).getValue().getValue(),listChilds.getChild(1).getValue().getValue())
			fi;
			self;
			}
			
	};
	init2(val: Int, childLeft: Int, childRigth: Int): BinaryTree{
		{
			node<- (new NodeInt).init(val);
			leftchild<- (new BinaryTree).init(childLeft,new ListTree);
			rightchild<- (new BinaryTree).init(childRigth,new ListTree);
			self;
		}
	};
	getNode():NodeInt{
		node
	};
	assert(a:Bool, b:Int):Object{
		if a then
			b
		else
			~b
		fi

	};
	testing():Object{
		{
			let a:Int <- 1+2+3+4 in a;
			assert(~2 = (0 - 2), 257);
    		assert(~2 < 2, 258);
    		assert(~0 = 0, 259);
		}
	};
	
};

class NodeInt{
	value: Int;
	init(value:Int): NodeInt{
		{
			value<-value;
			self;
		}
	};
	getValue(): Int{
		value
	};
	setValue(value: Int): Int{
			value<- value
		};
};
class Tree{
	node: NodeInt;
	childs: ListTree;
	io: IO;
	init(value:Int): Tree{
		{
			node<- (new NodeInt).init(value);
			childs<-new ListTree;
			io<-new IO;
			self;
		}
	};
	init1(value: Int, listChilds: ListTree): Tree{
		{
			node<- (new NodeInt).init(value);
			childs<-listChilds;
			io<-new IO;
			self;
		}
	};
	getValue(): NodeInt{
		node
	};
	addchild(value: Int): Void{
		childs.add((new Tree).init(value))
	};
	preOrder(i:Int): Void{
		{
		
			io.out_int(node.getValue());
			if not childs.count()=0 then 
				{
					i<- new Int;
					while childs.count()>i loop
						{
							(childs.getChild(i)).preOrder(0);
							i<- i+1;
						}
						pool;
				}
				fi;
				new Void;
		}
	};

};

class ListTree{
add(tree: Tree): Void{ new Void};
count():Int{0};
getChild(i:Int): Tree{ new Tree};
};
class P {
  x:Int <- 3;
};
class C2 inherits P {
  getX():Int { x };
  setX(i:Int):Int { x <- i };
  test():Int{
  	{
  		x<-getX();
  		
  	}
  };
};
