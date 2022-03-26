"""
Alex Petty
Advance Topics In Computer Programming
5/8/17
Chapter 12
"""
 
import pygame
import random
# Define some colors
BLACK = (0, 0, 0)
WHITE = (255, 255, 255)
GREEN = (0, 255, 0)
RED = (255, 0, 0)
BLUE = (0, 0, 255)
pygame.init()
class Rectangle():
    def __init__(self):
        self.x = random.randrange(0,701)
        self.y = random.randrange(0,500)
        self.w = random.randrange(20,70)
        self.h = random.randrange(20,70)
        self.change_x = random.randrange(-3,3)
        self.change_y = random.randrange(-3,3)
        self.r = random.randint(0,255)
        self.g = random.randint(0,255)
        self.b = random.randint(0,255)

        if self.change_y == 0:
            self.change_x += 1
        if self.change_y == 0:
            self.change_y += 1
        
    def draw(shape):
        pygame.draw.rect(screen,(shape.r,shape.g,shape.b),[shape.x,shape.y,shape.w,shape.h])
    def move(shape):
        shape.x += shape.change_x
        shape.y += shape.change_y
class Ellipse(Rectangle):
    def draw(shape):
        pygame.draw.ellipse(screen,(shape.r,shape.g,shape.b),[shape.x, shape.y, shape.w, shape.h])
# Set the width and height of the screen [width, height]
size = (700, 500)
screen = pygame.display.set_mode(size)
mylist = []
for i in range(1000):
    my_object = Rectangle()
    mylist.append(my_object)
for i in range(10):
    my_object = Ellipse()
    mylist.append(my_object)
pygame.display.set_caption("My Game")
 
# Loop until the user clicks the close button.
done = False

# Used to manage how fast the screen updates
clock = pygame.time.Clock()
 
# -------- Main Program Loop -----------
while not done:
    # --- Main event loop
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            done = True
 
    # --- Game logic should go here
 
    # --- Screen-clearing code goes here
 
    # Here, we clear the screen to white. Don't put other drawing commands
    # above this, or they will be erased with this command.
 
    # If you want a background image, replace this clear with blit'ing the
    # background image.
    screen.fill(WHITE)
    for j in range(len(mylist)):
        mylist[j].draw()
        mylist[j].move()
    my_object.draw()
    my_object.move()
    # --- Drawing code should go here
 
    # --- Go ahead and update the screen with what we've drawn.
    pygame.display.flip()
 
    # --- Limit to 60 frames per second
    clock.tick(60)
 
# Close the window and quit.
pygame.quit()
