'''
Name: Alex Petty
Project: Chapter 7 (Adventure)
Date: 5/18/16
Description: The following program simulates an adventure game
'''
done = False
current_room = 0
room_list = []

room = [None,None,None,None,None]
room = ["You are in the Front Yard! There is a door to the North(N).",1,None,None,None]
room_list.append(room)

room = [None,None,None,None,None]
room = ["You are in the Main Room! There is a door to the North(N), South(S), East(E), & West(W)",4,2,0,3]
room_list.append(room)

room = [None,None,None,None,None]
room = ["You are at the Demon Altar! There is a door to the North(N).",6,None,None,1]
room_list.append(room)

room = [None,None,None,None,None]
room = ["You are on the Balcony! There is a door to the East(E).",None,1,None,None]
room_list.append(room)

room = [None,None,None,None,None]
room = ["You are in the Family Crypt! The is a door to the South(S) and West(W).",None,None,1,5]
room_list.append(room)

room = [None,None,None,None,None]
room = ["You are in the Guest Room! There is a door to the East(E)",None,4,None,None]
room_list.append(room)

room = [None,None,None,None,None]
room = ["You are in the Devil's Den! there is a door to the South(S).",None,None,2,None]
room_list.append(room)

while done == False:
    print(room_list[current_room][0])
    print(current_room)
    direction = raw_input("Which way? ")
    direction = direction.upper()
    if direction == "N":
        next_room = room_list[current_room][1]
        if next_room == None:
            print("There's no invisible door there pal!")
            print("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^")
        else:
            current_room = next_room
    elif direction == "E":
        next_room = room_list[current_room][2]
        if next_room == None:
            print("There's no invisible door there pal!")
            print("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^")
        else:
            current_room = next_room
    elif direction == "S":
        next_room = room_list[current_room][3]
        if next_room == None:
            print("There's no invisible door there pal!")
            print("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^")
        else:
            current_room = next_room
    elif direction == "W":
        next_room = room_list[current_room][4]
        if next_room == None:
            print("There's no invisible door there pal!")
            print("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^")
        else:
            current_room = next_room 
            
