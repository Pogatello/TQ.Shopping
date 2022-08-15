# TQ.Shopping

Class library (.NET 6) for a shopping basket with discounts included. Covered by a few unit tests.
Focus was on demonstrating base concepts instead of a concrete implementation of functionalities.

## Task

Make a shopping basket with option of adding products and calculating total sum with all discounts applied.
Every time a total is required, it is supposed to be logged with all shopping basket details.

To be implemented as class library.

Looking for good understanding of OOP, SOLID, TDD.
Keep things simple, do not overengineer.

## Test Cases and Data

Test articles: 
- Bread (1$)
- Butter (0.8$)
- Milk (1.15$)

Required discounts:
- Buy 2 butters, get one bread 50% off
- Buy 3 milks, get 4th milk for free

Expected Results:
Contained within unit tests

## Notes

Comments left in code for discussion.

## Known problems

Percentage discount will be applied only once (can be changed depending on the business rule)

At the moment, total sum can be called only once. Otherwise, discounts are applied multiple times. Commented in code.
Could implement ResetDiscountsMethod to remove percentage discount/gratis articles, but would also need flags on Article object to track wheteher the discount was applied or the article was given as extra(gratis - combo discount).

Left out that functionality to keep it simple.