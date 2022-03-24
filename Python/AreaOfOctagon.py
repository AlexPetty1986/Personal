'''
Name: Alex Petty
Project: Chapter 1 (Area Calculator)
Date: 2/10/2016
Description: The following program finds the area of an octagon
'''

import math
side = float(input("Please enter the length of one of the sides of the
octagon:"))
area =( 2 * (1 + math.sqrt(2))*(side)**2)
print("The area of the octagon is approximately:",round(area,2))
