'''
Alex Petty
Advance Topics In Computer Programming
3/24/17
Functions D
'''

import random
def create_list(size):
    my_list = []
    for i in range(size):
        n = random.randrange(1,7)
        my_list.append(n)
    return(my_list)
def count_list(my_list):
    for i in range(1,7):
        count = 0
        for j in range(len(my_list)):
            if i == my_list[j]:
                count = count + 1
        print("Number",i, "was generated",count,"times.") #display

def average_list(my_list):
    total = 0
    for i in range(len(my_list)):
        total = total + my_list[i]
        average = total/len(my_list)
    print("Average of numbers:",average) #display
def main():
    limit = 10000
    numbers = create_list(limit)
    count_list(numbers)
    average_list(numbers)
main() #display

