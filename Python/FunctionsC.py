'''
Alex Petty
Advance Topics In Computer Programming
4/6/17
Functions C
'''

def find(list,key):
    for i in range(len(list)):
        if key == list[i]:
            print("Found", key, "at position", i)

my_list = [36, 31, 79, 96, 36, 91, 77, 33, 19, 3, 34, 12, 70, 12, 54, 98, 86, 11, 17, 17]

find(my_list, 12)

find(my_list, 91)

find(my_list, 80)
