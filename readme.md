#DivideAmountWithCoins

DivideAmountWithCoins is an solution to algorithmic exercise. I believe I encountered the problem at [the Danish Developer Conference 2013](http://steen.hulthin.dk/blog/danish-developer-conference-2013/) in the some commercial information from [d60](http://www.d60.dk/) where it was included as a brainteaser. 

##The Problem

The problem is: how many ways can you make a given amount (ie 9) with (unlimited) coins of given values (ie 5, 2 and 1)?

##The Solution

There are off course several ways to solve this problem in code. I believe there was some hints in the problem text - otherwise I would most likely not have solved as easily. I would love to see the original problem text or know if the problem (or problemtype) has a name. Please give me a shout if you know. 

Anyway (I read this from the code I wrote a year ago) it turns out that the number of ways to make the given amount is equal to the number of ways you can make the given amount with all the coin values except for one plus the number of ways you can make the given amount minus the excepted coin value and all the coin values. That was clear, right?

##The Math behind

### Warning - just by reading this you will kill kittens - it's most likely not a very good explanation. Sorry it's the best I can do in the given time. The given time here, by the way, is my life.

I don't even know how to write that mathematically, but I'll give it a shot:

I'll call: 

* the given amount ( `n` ) (the one you want to make).
* the ways you can make a given amount with the given coins `result`. 
* the given coin values mall = m1, m2, m3 ... mx ( m1 = 5, m2 = 2 and m3 = 1 in the example in the problem section ).

`n given mx  = n given ( mall - mx ) + ( n - mx ) given mx`

Combine this with the following:

* If you don't have any coins you can't make any amount. 
* If the amount you need to make is zero, you have an easy task (yes, you are done with that now.)
* If all your coins are larger than the amount you need to make you are out of luck (and the number of ways make the given amount is zero). 

Now it is a matter of recursively using the formula until reaching one of the above conditions (and counting the number of times you go through the recursion). 
##Example

How many way can I get the amount 15 
