# author: Ray Hsiao
# title: Interview Draft

VAR variable_string = ""
EXTERNAL generateString(source)
EXTERNAL changeColor(color)

Hello, and welcome! I'm your interviewer for today.
Do you have any questions before we start?
* ["No, I'm good to go!"]
  Okay, let's move on then. -> self_intro
* ["Yes, actually."]
  Well, that's too bad! Moving on... -> self_intro
* ["Uhhhh-"]
  Okay, we'll be moving on. -> self_intro

=== self_intro ===
Can you tell me about yourself? 
* [Be confident] -> generate_introduction
* [Be outrageous] -> generate_introduction
* [Be humble] -> generate_introduction

=== generate_introduction ===
~generateString("Introduction")
{variable_string}
~generateString("Motivation")
{variable_string}
-> first_question

=== first_question ===
~changeColor("white")
Uh, okay. Sure.
Now let's get into the juicy stuff -- the actual questions.
Could you tell me about a time you collaborated with others?
-> generate_first_answer

=== generate_first_answer ===
~changeColor("black")
Okay, let me start off with the SITUATION.
~generateString("Situation")
{variable_string}
Now let me talk about my TASK.
~generateString("Task")
{variable_string}
And the ACTIONS I took to meet my goal.
~generateString("Action")
{variable_string}
Finally, the RESULT.
~generateString("Result")
{variable_string}
-> conclusion

=== conclusion ===
~changeColor("white")
...Thank you for your interest. 
Uh. 
I really don't know what to say.
I've never had a candidate like you before.
Uh.
I don't think we'll call you back.
Goodbye.
-> END



