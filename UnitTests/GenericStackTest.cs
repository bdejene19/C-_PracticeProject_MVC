using Xunit;
using TestProject.Players;


public class GenericStackTest
{
	[Fact]
	public void Stack_CanBe_GenericType()
	{
		GenericStack<int> IntegerStack = new (new List<int>());
		GenericStack<string> StringStack = new (new List<string>());
		GenericStack<PlayerClass> PlayerStack = new (new List<PlayerClass>());

		Assert.IsType<GenericStack<int>>(IntegerStack);
		Assert.IsType<GenericStack<string>>(StringStack);
        Assert.IsType<GenericStack<PlayerClass>>(PlayerStack);

    }


	[Fact]
	public void NewElement_GoesTo_Top()
	{
		GenericStack<int> IntegerStack = new (new List<int>());
		int ExpectedVal = 15;
		IntegerStack.PushToStack(1);
        IntegerStack.PushToStack(ExpectedVal);

        Console.Write(IntegerStack.Top);
		Assert.Equal(ExpectedVal, IntegerStack.GetTop());
	}

	[Fact]
	public void Top_IncrementsCorrectly_WithRemoval_And_Addition()
	{
        GenericStack<int> IntegerStack = new(new List<int>());
		Assert.Equal(-1, IntegerStack.Top);

		IntegerStack.PushToStack(1);
		Assert.Equal(0, IntegerStack.Top);

		IntegerStack.RemoveTop();
		Assert.Equal(-1, IntegerStack.Top);

		IntegerStack.PushToStack(1);
		IntegerStack.PushToStack(2);
		IntegerStack.PushToStack(3);
		 
		Assert.Equal(2, IntegerStack.Top);

    }

	[Fact]
	public void Throws_OutOfRange_Exception_RemovingFrom_EmptyList()
	{
        GenericStack<int> IntegerStack = new (new List<int>());

        Assert.Throws<IndexOutOfRangeException>(() => IntegerStack.RemoveTop());
    }

	[Fact]
	public void Throws_OutOfRange_Exception_WhenGettingTopValue_EmptyList()
	{
        GenericStack<int> IntegerStack = new(new List<int>());

        Assert.Throws<IndexOutOfRangeException>(() => IntegerStack.GetTop());
    }
}


