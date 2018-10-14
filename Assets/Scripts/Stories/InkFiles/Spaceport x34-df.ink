LIST chips = x34, y

Spaceport 'x34-df'
Residence of Captain Trick Dogleg.
-> Welcome

=== Welcome ===
#x34-df
Welcome to humble abode young scavenger.  What can I help you with?

+ "I'm on the look out for band of pirates who go by the name of The second sons.  Have you heard of anything like this happending around these parts?"
    -> pirates
+ "I'd like to know if you have any de45-cf circuit boards for a mark II Helios robot" -> robot


=== robot ===
"Sure thing, I got heaps of them.  Here's a couple for free.."
+ [take the circuit boards]
~ chips = "x34"
    -> decision


=== pirates ===
"I don't want nothing to do with pirates.  I think you should leave".
    -> decision

=== decision ===
What do you want to do now?
+ [leave] -> ending

=== ending
{ chips ? "x34":
    "Thanks for the chips.  I'll see you later."
- else:
    "Thanks for your help, I'll be on my way now mate."
}
-> DONE



