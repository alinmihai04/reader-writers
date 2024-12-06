Hi *, i have the following situation:

I need to solve the reader-writers problem in Java, for now with the readers-preferred approach. The test that needs to pass creates 100 separate tasks, around 80 are writes and around 20 are reads, each write has an internal sleep of around 100ms and each read has a sleep of around 250ms. All these tasks should run in maximum 10 seconds, by having 10 available threads.

I tried all sorts of implementations, but the result is always far away from the 10 seconds mark for Java. I implemented the same thing in C# and the tasks are being run in 8-9 seconds each time, so maybe is just a problem in my Java code, not in the whole logic.

This is the Github repo with both C# and Java solutions: https://github.com/alinmihai04/reader-writers

The main classes are "TaskExecutor", "ReadPreferredExecutor" and "ExecutorTest" (this is being run) for both solutions. For java i used JDK 21 and IntelliJ IDEA 2022 (if it matters).

The question is, what am I doing so wrong in the Java implementation or maybe there is a configuration problem? Thanks!
