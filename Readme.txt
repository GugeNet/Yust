The library contains a small compiler class that takes an expression such as 
"2 + 2" and can build a Proglet<int> out of this and Eval it to be 4.

It can also use variables passed to it in the form of IDictionary<string, object> and
Evaluate expressions such as "Age > 23" and return a bool if you should consider
offering another person a salad made from an olive and a traditional vermouth and gin dressing.

Nothing is very finished yet, but the compiler uses a clever trick I found out for myself
when I was 20 years old and implemented this in BASIC on a 286 PC with MSDOS 3.0!
It is a little bit like Dijstra's shunting yard, but not quite.

Operator precedence as defined in
https://en.cppreference.com/w/cpp/language/operator_precedence
