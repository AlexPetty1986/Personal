'''
Name: Alex Petty
Project: Chapter03 (Quiz Game)
Date 3/01/16
Description: The following Program tests you videogame knowledge.
'''

#Question 1 and Answer 1
question1 = '''
True or False:
The Yato from Fire Emblem: Fates has the most forms in the series.
(a) True
(b) False
'''
score = 0
answer1 = "a"
#Asks question
print(question1)
response = input("Answer: ")
response = response.lower()

if response == answer1:
    print('''Correct!
    Birthright: Noble Yato and Blazing Yato
    Conquest: Grim Yato and Shadow Yato
    Revelation: Alpha Yato and Omega Yato''')
    score = score + 10
else:
    print("Wrong!")
    score = score - 10
    
#Question 2 and Answer 2
question2 = '''
Which of these Limit Breaks is only usable by Cloud?
(a) Final Heaven
(b) Death Gigas
(c) Meteorain
(d) Lunatic High
'''
answer2 = "c"
print(question2)
response = input("Answer: ")
response = response.lower()

if response == answer2:
    print('''Correct!
    Final Heaven is used by Tifa
    Death Gigas is used by Vincent
    and Lunatic High is used by Red XIII''')
    score = score + 10
else:
    print("Wrong!")
    score = score - 10
    
#Question 3 and Answer 3
question3 = '''
What year did The Legend of Zelda: The Wind Waker come out in the US?
'''
answer3 = "2003"
#Will ask question here

print(question3)
response = input("Answer: ")
response = response.lower()

if response == answer3:
    print('''Correct!
    The Wind Waker would then get a HD remake in 2013
    on the Wii U.''')
    score = score + 10
else:
    print("Wrong!")
    score = score - 10

#Question 4 and Answer 4
question4 = '''
Name the character who says this quote: "Your range is one fist short."
'''
answer4 = "ryu"

#Asks question
print(question4)
response = input("Answer: ")
response = response.lower()

if response == answer4:
    print('''Correct!
    Ryu says this victory taunt in Super Smash Bros.
    for the 3DS and the Wii U.''')
    score = score + 10
else:
    print("Wrong!")
    score = score - 10

#Question5 and Answer5
question5 = '''
What is the strongest summon in Golden Sun: Lost Age
and Golden Sun: Dark Dawn?
'''
answer5 = ("iris")

#Will ask question
print(question5)
response = input("Answer: ")
response = response.lower()
if response == answer5:
    print('''Correct!
    Iris will do massive damage at the cost of
    9 Mars and 4 Mercury Djinn. As well has heal the entire party.''')
    score = score + 10
else:
    print("Wrong!")
    score = score - 10

#Question6 and Answer6
question6 = '''
Which of these Legend of Zelda games
did not have the Master Sword?
(a) Phantom Hourglass
(b) Link to the Past
(c) Twilight Princess
(d) Skyward Sword
'''
answer6 = ("a")

#Asks Question
print(question6)
response = input("Answer: ")
response = response.lower()

if response == answer6:
    print('''Correct!
    In Phantom Hourglass Link uses the Phantom Sword to defeat Bellum.
    ''')
    score = score + 10
else:
    print("Wrong!")
    score = score - 10
    
#Question7 and Answer7
question7 = '''
What is the name of the first Limit Break that Squall has
in Final Fantasy VIII?
'''
answer7 = ("renzokuken")

#Asks question
print(question7)
response = input("Answer: ")
response = response.lower()

if response == answer7:
    print('''Correct!
    After using the Renzokuken Squall will use one of the four
    finishing moves that he knows.
    ''')
    score = score + 10
else:
    print("Wrong!")
    score = score - 10
    
#Question8 and Answer8
question8 = '''
Mario's original name was Luigi.
(a) True
(b) False
'''
answer8 = ("b")

#Asks question
print(question8)
response = input("Answer: ")
response = response.lower()

if response == answer8:
    print('''Correct!
    Mario's original name was Jump Man.
    Luigi is the name of his brother.
    ''')
    score = score + 10
else:
    print("Wrong!")
    score = score - 10
    
#Question9 and Answer9
question9 = '''
Name this quote said by a character:
You answered the call of battle.
So i'll give you fight you'll never forget!
'''
answer9 = ("ike")

#Asks Question
print(question9)
response = input("Answer: ")
response = response.lower()

if response == answer9:
    print('''Correct!
    Ike will say this after initiating combat with him
    in Fire Emblem Fates
    ''')
    score = score + 10
else:
    print("Wrong!")
    score = score - 10
    
#Output score
total = score
print("Good Job, you got",score,"points.")
