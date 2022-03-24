'''
Name: Alex Petty
Project: Chapter 01(Project A)
Date: 2/5/16
Description: The following program is a temperature converter
'''
number1= float (input("Please enter current temperature in Farenheit:"))

#change int to float. If it doesn't work try something else
answer1 = number1 - 32
answer2 = answer1 * 5
answer3 = answer2 / 9 #Find a shorter way to make the program

print("Here is your temperature in Celsius:",round(answer3)) #add round to answer
