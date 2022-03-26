'''
Name: Alex Petty
Project: Chapter 6c
Date: 5/3/16
Description: The following program displays small green rectangles
'''
import pygame
WHITE = (255, 255, 255)
BLACK = (0, 0, 0)
GREEN = (0, 255, 0)
 
pygame.init()
 
size = (700, 500)
screen = pygame.display.set_mode(size)
 
pygame.display.set_caption("Green Rectangles")
 
done = False
 
clock = pygame.time.Clock()
 
while not done:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            done = True
    screen.fill(BLACK)
    for row in range(0,700,20):
        for column in range(0,500,20):
             pygame.draw.rect(screen,GREEN,[10 + row,10 + column,8,8],0)
 
    pygame.display.flip()
 
    clock.tick(60)

pygame.quit()
