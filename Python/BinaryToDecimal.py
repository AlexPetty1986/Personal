'''
Name: Alex Petty
Project: Chapter 2 (Binary Code)
Date: 02/24/16
Description: The following program converts binary code to decimal form or vice
versa
'''

print("Binary-Decimal Conversion")
choice = input("Would you like to convert to (b)inary or (d)ecimal?")
if choice== "b": #Binary Option
    b1 = (input("Please enter binary number:")) #Binary Input
    answer = int(b1, 2)
if choice == "d": #Decimal Option
    d1 = int(input("Please enter decimal number:")) #Decimal Input
    answer = bin(d1)
    answer = answer [2:]
print("Here is your answer:", answer) #Output
