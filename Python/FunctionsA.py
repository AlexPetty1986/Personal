'''
Alex Petty
Advance Topics In Computer Programming
3/24/17
Functions A
'''

def min3(a,b,c): #define min3
    if a <= b and a <= c:
        smallest = a
    elif b <= a and b <= c:
        smallest = b
    else:
        smallest = c
    return smallest

print(min3(4, 7, 5)) #display

print(min3(4, 5, 5)) #display

print(min3(4, 4, 4)) #display

print(min3(-2, -6, -100)) #display

print(min3("Z", "B", "A")) #display


