'''
Name: Alex Petty
Project: Chapter 4 (Camel)
Date: 3/07/16
Description: The following program is a mind game
'''
print('''Welcome to Legend of Zelda: Dungeon Crawler!
You are Link.
You've just found a dungeon that is said to have a rare treasure.
But after walking into the dungeon you're trapped inside.
While being confronted by your mirror self Dark Link.
You must find a way to escape without Dark Link killing you.
''')
dis_from_exit = 250
stamina = 25
dis_from_dark_link = -30
thirst = 0
potion_bottle = 5
import random
done = False
while done == False:
    print('''
(a) Walk
(b) Run
(c) Hide
(d) Status
(e) Drink
(q) Quit
''')

    choice = input("Your Choice:")
    choice = choice.lower()


    
    if choice == "a":
        meters = (random.randint(1,10))
        if thirst >= 0:
            thirst = thirst + 1
        if stamina <= 25:
            stamina = stamina - (random.randint(1,5))
        if dis_from_dark_link >= -30:
            dis_from_dark_link = dis_from_dark_link + (random.randint(1,5))
        if dis_from_exit <= 350:
            dis_from_exit = dis_from_exit - meters
        print("=============================================================")
        print("You decided to walk at a slow pace and moved", meters ,"meters.")
        print("=============================================================")

    elif choice == "b":
        meters = (random.randint(5,15))
        if thirst >= 0:
            thirst = thirst + 2
        if stamina <= 25:
            stamina = stamina - (random.randint(5,10))
        if dis_from_dark_link >= -20:
            dis_from_dark_link = dis_from_dark_link + (random.randint(-8,10))
        if dis_from_exit <= 350:
            dis_from_exit = dis_from_exit - meters
        print("=============================================================")
        print("You decide not to take any chances and ran", meters ,"meters")
        print("=============================================================")
    elif choice == "c":
        if stamina < 25:
            stamina = 25
        if dis_from_dark_link >= -30:
            dis_from_dark_link = dis_from_dark_link + (random.randint(0,5))
        print("=============================================================")
        print("You decide to hide to regain some of your stamina.")
        print("=============================================================")
    elif choice == "d":
        print("=============================================================")
        print("Distance from exit:", dis_from_exit,"yards left")
        print("Stamina:", stamina)
        print("Distance from Dark Link:", dis_from_dark_link)
        print("Thirst:", thirst)
        print("Potion bottles left:", potion_bottle)
        print("=============================================================")
    elif choice == "e":
        if potion_bottle >= 1:
            thirst = 0
            potion_bottle = potion_bottle - 1
            print("=============================================================")
            print("You've drank some potion and have", potion_bottle, "bottles left.")
            print("=============================================================")
        if dis_from_dark_link >= -20:
            dis_from_dark_link = dis_from_dark_link + (random.randint(1,10))
        if potion_bottle == 0:
            print("=============================================================")
            print("You've got no more potion left!")
            print("=============================================================")
    elif choice == ("Alex") or choice == ("alex"):
        print("=================================================================")
        print('''You realize you have the Ocarina of Time.
You play you Ocarina and warp out of the dungeon unharmed.
Congrats you won the game. (SECRETLY).''')
        print("=================================================================")
        done = True

        
    if choice.upper() == "Q":
        print("What a sore loser!")
        done = True            
    
    if 0 <= stamina and stamina <= 10:
        print("You're getting tired!")
    elif stamina < 0:
        print("You collapsed from exhaustion!")
        print('''
              `:#@+,`             
           :@@@@@@@@@@#`          
         :@@@@@@@@@@@@@@@`        
        ##@@@@@@@@@@@@@@@@;       
      `@@@@@@@@@@@@@@@@@@@@@      
      @@@@@@@@@@@@@@@@@@@@@@@     
     @@@@@@@@@@@@@@@@@@@@@@@@'    
    +@@@@@@@@@@@@@@@@@@@@@@@@@`   
    @@@@@@@@@@@@@@@@@@@@@@@@@@@   
   #@@@@@@@@@@@@@@@@@@@@@@@@@@@`  
   @@@@@@@@@@@@@@@@@@@@@@@@@@@@@  
  .@@@@@@@@@@@@@@@@@@@@@@@@@@@@@  
  +@@@@@@@@@@@@@@@@@@@@@@@@@@@@@. 
  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@, 
  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@+ 
  @@@@@@`    ,@@@@@@@     ;@@@@@@ 
  @@@@@`      ;@@@@@       +@@@@@ 
  @@@@@        @@@@@        @@@@@ 
  @@@@@        @@@@,        @@@@@ 
  @@@@@        @@@@:        @@@@@ 
  @@@@@        @@@@@       `@@@@@ 
  @@@@@;      @@@@@@,      @@@@@@ 
  @@@@@@'    @@@@'@@@;    @@@@@@@ 
  @@@@@@@@@@#@@#. +@@@@@#@@@@@@@; 
   +@@@@@@@@@@@@  `@@@@@@@@@@@@:  
    :@@@@@@@@@@.   #@@@@@@@@@@`   
      @@@@@@@@@@@@@@@@@@@@@@@     
       ##@@@@@@@@@@@@@@@@@@:      
        :@@@@@@@@@@@@@@@@@`       
         @@@@@@@@@@@@@@@@;        
         @@@@+@@@+@@@+@@@;        
         @@@, @@: @@; @@@;        
         @@@, @@: @#; @@@'        
         @@@` @@, #@: ##@:        ''')
        done = True
    if thirst >= 4 and thirst < 6 and done == False:
        print("You're starting to get thirsty!")
    elif thirst > 6:
        print("You died from dehydration!")
        print('''
              `:#@+,`             
           :@@@@@@@@@@#`          
         :@@@@@@@@@@@@@@@`        
        ##@@@@@@@@@@@@@@@@;       
      `@@@@@@@@@@@@@@@@@@@@@      
      @@@@@@@@@@@@@@@@@@@@@@@     
     @@@@@@@@@@@@@@@@@@@@@@@@'    
    +@@@@@@@@@@@@@@@@@@@@@@@@@`   
    @@@@@@@@@@@@@@@@@@@@@@@@@@@   
   #@@@@@@@@@@@@@@@@@@@@@@@@@@@`  
   @@@@@@@@@@@@@@@@@@@@@@@@@@@@@  
  .@@@@@@@@@@@@@@@@@@@@@@@@@@@@@  
  +@@@@@@@@@@@@@@@@@@@@@@@@@@@@@. 
  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@, 
  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@+ 
  @@@@@@`    ,@@@@@@@     ;@@@@@@ 
  @@@@@`      ;@@@@@       +@@@@@ 
  @@@@@        @@@@@        @@@@@ 
  @@@@@        @@@@,        @@@@@ 
  @@@@@        @@@@:        @@@@@ 
  @@@@@        @@@@@       `@@@@@ 
  @@@@@;      @@@@@@,      @@@@@@ 
  @@@@@@'    @@@@'@@@;    @@@@@@@ 
  @@@@@@@@@@#@@#. +@@@@@#@@@@@@@; 
   +@@@@@@@@@@@@  `@@@@@@@@@@@@:  
    :@@@@@@@@@@.   #@@@@@@@@@@`   
      @@@@@@@@@@@@@@@@@@@@@@@     
       ##@@@@@@@@@@@@@@@@@@:      
        :@@@@@@@@@@@@@@@@@`       
         @@@@@@@@@@@@@@@@;        
         @@@@+@@@+@@@+@@@;        
         @@@, @@: @@; @@@;        
         @@@, @@: @#; @@@'        
         @@@` @@, #@: ##@:        ''')
        done = True
    if dis_from_dark_link >= 0 and dis_from_dark_link < 25:
        print("You notice Dark Link behind and closing in.")
    elif dis_from_dark_link >= 25:
        print("Dark Link has captured you! The return of Ganon is now!")
        print('''
              `:#@+,`             
           :@@@@@@@@@@#`          
         :@@@@@@@@@@@@@@@`        
        ##@@@@@@@@@@@@@@@@;       
      `@@@@@@@@@@@@@@@@@@@@@      
      @@@@@@@@@@@@@@@@@@@@@@@     
     @@@@@@@@@@@@@@@@@@@@@@@@'    
    +@@@@@@@@@@@@@@@@@@@@@@@@@`   
    @@@@@@@@@@@@@@@@@@@@@@@@@@@   
   #@@@@@@@@@@@@@@@@@@@@@@@@@@@`  
   @@@@@@@@@@@@@@@@@@@@@@@@@@@@@  
  .@@@@@@@@@@@@@@@@@@@@@@@@@@@@@  
  +@@@@@@@@@@@@@@@@@@@@@@@@@@@@@. 
  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@, 
  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@+ 
  @@@@@@`    ,@@@@@@@     ;@@@@@@ 
  @@@@@`      ;@@@@@       +@@@@@ 
  @@@@@        @@@@@        @@@@@ 
  @@@@@        @@@@,        @@@@@ 
  @@@@@        @@@@:        @@@@@ 
  @@@@@        @@@@@       `@@@@@ 
  @@@@@;      @@@@@@,      @@@@@@ 
  @@@@@@'    @@@@'@@@;    @@@@@@@ 
  @@@@@@@@@@#@@#. +@@@@@#@@@@@@@; 
   +@@@@@@@@@@@@  `@@@@@@@@@@@@:  
    :@@@@@@@@@@.   #@@@@@@@@@@`   
      @@@@@@@@@@@@@@@@@@@@@@@     
       ##@@@@@@@@@@@@@@@@@@:      
        :@@@@@@@@@@@@@@@@@`       
         @@@@@@@@@@@@@@@@;        
         @@@@+@@@+@@@+@@@;        
         @@@, @@: @@; @@@;        
         @@@, @@: @#; @@@'        
         @@@` @@, #@: ##@:        ''')
        done = True
    if dis_from_exit <= 0:
        print('''You've escaped the dungeon without getting caught by Dark Link.
But it isn't the last time you will see him.                                                                                                                                  
Congrats you won the game''')
        print('''                               
                   `###                    
                   #  `'                   
                   #   +                   
                   +' +`                   
                `'###++##:                 
              +#####++#####+;              
            ++#####++ ####+###'            
          ;++#+###++   ##+#####+`          
         +++## ##++#` ##+##':#++#,         
        #++##`  ++####++##+  '+###;        
       #++###',`+#####+####  +#####,       
      '++#:###++#####+#####++###`#++       
     `++.   #++#####+#####++##,  `+##      
     ++##` #++#####+#####++####: +###'     
    ,+###;#'+#####+###'#++#####:+:####     
    +#####++#####+###` ++#####++#####+;    
    ##+ #++#####+##+   +#####++#### +##    
   '##` ;+#####+##.    #####++####  ###    
   ###   #####+##      ####++#####  ;##:   
   ###   ####+###'     ###++#####+  :##+   
   ##+.  ###+#####++   ##++#####+#  #+++   
   #' ` ,##+#####++#   #++#####+## .  +#   
   ++  .##+#####++##   ++#####+####   ##   
   +#   #+#####++###   +#####+####;   ##   
   ##;  '#####++####   #####+#####   ###   
   ###, ;####++#####   ####+#####+  +###   
   #+  :####++#####+   ###+#####++'`  #'   
   +#    ##++#####++   ##+#####++#    +`   
   `+;   ;++#####++#   #+#####++#    ++    
    ##'   +#####++##   +#####++##   +++    
    '#'.,+#####++#####+#####++###;.,+#     
     #'    '##++#####+#####++##`    ##     
     :+;    '++#####+#####++##     ##      
      +##'  ,+#####+#####++###` .+##:      
       ###`    :##+#####++#`    :##+       
        ##       +#####++#      `##        
         ++#;:;'     ,     +:;'###         
          ####,     ++:     ++##'          
           :##+;,;##++##+:,++##            
             '#####++#####++#.             
               `+#++#####+'              ''')   
        done = True
    if 1 == random.randint(1,10):
        potion_bottle = 5
        print("You found a cauldron full of potion and decide to refill all of your bottles.")
