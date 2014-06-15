#DivideAmountWithCoins

DivideAmountWithCoins is an solution to algorithmic exercise. I believe I encountered the problem at [the Danish Developer Conference 2013](http://steen.hulthin.dk/blog/danish-developer-conference-2013/) in the some commercial information from [d60](http://www.d60.dk/) where it was included as a brainteaser. 

##Project status

This project is done. Feel free to contact me if you have a question. You can [reach me on twitter](http://www.twitter.com/steenhulthin)

##The Problem

The problem is: how many ways can you make a given amount (ie 7) with (unlimited) coins of given values (ie 4, 2 and 1)?

##The Solution

There are off course several ways to solve this problem in code. I believe there was some hints in the problem text - otherwise I would most likely not have solved as easily. I would love to see the original problem text or know if the problem (or problemtype) has a name. Please give me a shout if you know. 

Anyway (I read this from the code I wrote a year ago) it turns out that the number of ways to make the given amount is equal to the number of ways you can make the given amount with all the coin values except for one plus the number of ways you can make the given amount minus the excepted coin value and all the coin values. That was clear, right?

##The Math behind

### Warning - just by reading this you will kill kittens - it's most likely not a very good explanation. Sorry it's the best I can do in the given time. The given time here, by the way, is my life.

I don't even know how to write that mathematically, but I'll give it a shot:

I'll call: 

* the given amount ( `n` ) (the one you want to make - 7 in the example in the problem section).
* the ways you can make a given amount with the given coins `result`. 
* the given coin values coins[all] = coins[a, b, c ... x] ( coins[a] = coin value 4, coins[b] = coin value 2 and coins[c] = coin value 1 in the example in the problem section ).

Due to magic, unicorns and mathematicians we known that:

`n given coins[all]  = n given ( coins[all] - coins[x] ) + ( n - coins[x] ) given coins[all]`

> notice that the `n given ( coins[all] - coins[x] )` is same as `n given coins[all]` just with smaller set of coins. And `( n - coins[x] ) given coins[all]` is also the same as `n given coins[all]` just with a smaller amount. This means that we can apply the same formula to calculate those value (and so on). But when do we stop? Read on!

The program returns (stops announcing the number of solutions) when one of the following conditions are met:

1. If you don't have any coins you can't make any amount (and the number of ways make the given amount is zero). 
2. If the amount you need to make is zero, you have an easy task since you have already made that amount (and the number of ways make the given amount is one).
3. If all your coins are larger than the amount you need to make you are out of luck (and the number of ways make the given amount is zero). 

Now it is a matter of recursively using the formula until reaching one of the above conditions (and counting the number of times you could actually make the amount (as per 2.)). 

##Example

How many way can I get the amount 7 with the coins 4, 2 and 1?

Let's first go through all the combinations:

* 4, 2, 1
* 4, 1, 1, 1
* 2, 2, 2, 1
* 2, 2, 1, 1, 1
* 2, 1, 1, 1, 1, 1
* 1, 1, 1, 1, 1, 1, 1

Ok, it's clear that the result is that we can make the amount 7 in 6 ways combining the coins values 4, 2 and 1. 

So let's look at the formula: 

`n given mall  = n given ( mall - mx ) + ( n - mx ) given mx`

7 given coins[4, 2 and 1] = 7 given coins[2 and 1] + 3 given coins[4, 2 and 1]

And now calculate 7 given coins[2 and 1] like

7 given coins[2 and 1] = 7 given coins[1] + 5 given coins[2 and 1]

and similarly 3 given coins[4, 2 and 1] (I'm not going to now)

Let's look more at 

7 given coins[2 and 1] = 7 given coins[1] + 5 given coins[2 and 1]

7 given coins[1] This is reduced now reduced sufficiently for us to use rule 4 and we count that as a solution. 5 given coins[2 and 1] can be reduced like this:

5 given coins[2 and 1] = 5 given coins[1] + 3 given coins[2 and 1]

Now again 5 given coins[1] has one solution (just like 7 given coins[2 and 1] before) and we can count that as another solution. Now we go on in the same way with: 

3 given coins[2 and 1] = 3 given coins[1] + 1 given [2 and 1]

3 given coins[1] has one solution (just like 7 given coins[1]. Regarding 1 given [2 and 1] :

1 given [2 and 1] = 1 given coins[1] + -1 given coins[2 and 1]

1 given coins[1] = 1 given coins[] + 0 given coins[1]

