'''
Name: Alex Petty
Project: Chapter 1 (Area of Trapezoid)
Date: 2/9/2016
Description: The following program finds the area of a trapezoid
'''
base1 = float(input("Please enter base 1 of the trapezoid:"))
base2 = float(input("Please enter base 2 of the trapezoid:"))
height = float(input("Please enter the height of the trapezoid:"))

answer1 = base1 + base2
answer2 = answer1 / 2 #Next time change equation
area = answer2 * height

print("Here is the area of your trapezoid:",(area)) #Change if any errors occur
