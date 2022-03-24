'''
Name: Alex Petty
Project: Chapter 05 (Create-A-Picture)
Date: 4/7/16
Description: The following program creates a picture
'''

import pygame
pygame.init()

#COLORS
BLACK = (0, 0, 0)
RED = (255, 0, 0)
BLUE = (0, 0, 255)
GREEN = (0, 255, 0)
GRASS = (116, 181, 91)
SKY = (130, 235, 237)
PIPE = (85, 217, 89)
WHITE = (255, 255, 255)
BROWN = (148, 112, 101)
GOOMBAHEAD = (163, 120, 26)
GOOMBABODY = (237, 193, 130)
GRAY = (155, 173, 179)
#SCREEN SIZE
size = (700,500)
screen = pygame.display.set_mode(size)

#WINDOW TITLE
pygame.display.set_caption("Petty - Chapter 05 (Create-a-picture)")
done = False

clock = pygame.time.Clock()

while not done:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            done = True


    screen.fill(WHITE)
    pygame.draw.rect(screen,BROWN,[0,0,700,100],0)
    pygame.draw.rect(screen,BROWN,[0,400,700,100],0) #DIRT
    pygame.draw.rect(screen,GRASS,[0,280,700,150],0) #GRASS
    pygame.draw.rect(screen,SKY,[0,0,700,375],0) #SKY
    pygame.draw.rect(screen,PIPE,[100,275,100,100],0) #WARP PIPE 1
    pygame.draw.rect(screen,PIPE,[500,275,100,100],0) #WARP PIPE 1
    pygame.draw.rect(screen,PIPE,[475,250,150,25],0) #WARP PIPE TOP 1
    pygame.draw.rect(screen,PIPE,[75,250,150,25],0) #WARP PIPE TOP 2
    pygame.draw.circle(screen,GOOMBAHEAD,[350,320],35,0) #GOOMBA HEAD
    pygame.draw.rect(screen,SKY,[300,330,175,40],0)
    pygame.draw.ellipse(screen,BROWN,[310,355,30,20],0) #GOOMBA FOOT 1
    pygame.draw.ellipse(screen,BROWN,[360,355,30,20],0) #GOOMBA FOOT 2
    pygame.draw.rect(screen,GOOMBABODY,[325,330,50,30],0) #GOOMBA BODY
    pygame.draw.line(screen,GOOMBAHEAD,[330,370],[370,315],0)
    for i in range(0,700,200): #CLOUDS
        pygame.draw.circle(screen,WHITE,[50+i,125],20,0)
        pygame.draw.circle(screen,WHITE,[75+i,125],20,0)
        pygame.draw.circle(screen,WHITE,[100+i,125],20,0)
        pygame.draw.circle(screen,WHITE,[125+i,125],20,0)
        pygame.draw.circle(screen,WHITE,[150+i,125],20,0)
        pygame.draw.circle(screen,WHITE,[175+i,125],20,0)
        pygame.draw.circle(screen,WHITE,[60+i,100],20,0)
        pygame.draw.circle(screen,WHITE,[80+i,100],20,0)
        pygame.draw.circle(screen,WHITE,[100+i,100],20,0)
        pygame.draw.circle(screen,WHITE,[120+i,100],20,0)
        pygame.draw.circle(screen,WHITE,[140+i,100],20,0)
        pygame.draw.circle(screen,WHITE,[160+i,100],20,0)
        pygame.draw.circle(screen,WHITE,[70+i,75],20,0)
        pygame.draw.circle(screen,WHITE,[90+i,75],20,0)
        pygame.draw.circle(screen,WHITE,[110+i,75],20,0)
        pygame.draw.circle(screen,WHITE,[130+i,75],20,0)
        pygame.draw.circle(screen,WHITE,[150+i,75],20,0)
    for i in range(330,370,20):
        pygame.draw.circle(screen,WHITE,[10+i,310],10,0)
        pygame.draw.circle(screen,BLACK,[10+i,315],6,0)
    

    pygame.display.flip()
    clock.tick(60)
pygame.quit()
