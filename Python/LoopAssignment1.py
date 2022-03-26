'''
Name: Alex Petty
Project: Chapter 6a
Date: 5/2/16
Description: The following program prints a triangle out of numbers
'''
a = 10 # VARIABLE SEPERATE FROM PROGRAM
for row in range(9):
    for column in range(row+1):
        print(a, end=" ")
        a = a + 1
    print() #OUTPUT
