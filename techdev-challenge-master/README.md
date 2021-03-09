# LexisNexis TechDev Technical Review

### Commentary Sentiment Checker
---
### Overview

LexisNexis has a content repository containing large amounts on commentary material. We would like to scan this commentary and determine the sentiment expressed by the author.

The following analytics needs to be tracked:

  - The number of 'positive' commentary files
  - The number of 'neutral' commentary files
  - The number of 'negative' commentary files

Commentary files containing statements are stored under the **commentary** directory within the project. All text files in the directory should be scanned and a final analytics report should be produced by printing the results to the console window.

#### Requirements
  - Git
  - .Net 4.0 or later

---
### Objectives
Below are 3 tasks that need to be completed by updating the existing code provided in the project. When you're done, please upload your solution to your own repository and share the url, or alternatively you can zip and send it to us via email.

##### 1. Debugging problems

There are a few of bugs in the code. Our manager has stated that the total values on the report are incorrect and that if a statement matches more than one sentiment analytic **rule**, this needs to be accounted for. The report also does not seem to pick up any negative sentiments. Please fix these bugs so that the final report displays the correct values.

##### 2. Object Oriented Programming (OOP)

The program would be difficult to maintain if we started adding a lot of new statement analytic **rules** to the sentiment analysis model (we would end up with a lot of "if" clauses for each **rule** in the model). Using Object Oriented Programming (OOP) design principles, rewrite the sentiment analysis model algorithm to make it more extensible/pluggable for adding new statement analytic **rules**.

The following new statement analytic **rules** also need to be added:

  - Add a new analytic rule that will increase the negative sentiment counter when the word **sad** is found.

  - Add a new analytic rule that will increase the negative sentiment counter when an email address and the word (or part of the word) **complaint** exist in the same statement.
 
##### 3. Multi-threading

The number of commentary files are expected to increase into the thousands, resulting in a large amount of time required to generate the final report. Currently the files are processed sequentially. Use your knownledge of multi-threaded programming so that these files may be processed concurrently using separate threads (one thread per file). At any given time, there can be thousands of commentary files in the **commentary** folder which might crash the app if we create too many threads.