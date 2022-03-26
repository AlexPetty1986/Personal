'''
Name: Alex Petty
Project: Chapter 6b
Date: 5/2/16
Description: The following program prints a box
'''

n = int(input("Please enter size of box:",)) #INPUT
for line1 in range(0,n,1): #TOP OF SQUARE
    print("*",end=" ")
print("")
for mstart in range(0,n-2,1): #MIDDLE LINES
    print("*", end=" ")
    for mend in range(1,n-1,1):
        print(" ", end=" ")
    print("*")

for last in range(0,n,1): #BOTTOM OF SQUARE
    print("*", end=" ")
