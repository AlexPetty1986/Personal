########### Test 1 - Part 2 ###########
# Author      : Alex Petty                                  
# Program Name: Test1.asm                                 
# Description : Program which implements the following 
#    formula:  3x + 5y - 2.   The numbers 3, 5, and 2
#    should be loaded from the data section as constants.
#    input x and y from the console and display the answer.        
#    Submit your answer to the Midterm - Part 2 dropbox
#    in Blackboard.
# BEGIN Midterm
#   get numbers from memory
#   prompt for variables x and y
#   input for x and y
#   save x and y
#   equation stuff
#   write answer on the screen
#   end program
# END Midterm
###############################################

	.text
main:
	#get numbers from memory
	lw $t0, num1
	lw $t1, num2
	lw $t2, num3
	
	#prompt for variable x
	li $v0, 4
	la $a0, var1
	syscall
	
	#input variable x
	li $v0, 5
	syscall
	
	#save variable x
	move $t3, $v0
	
	#prompt for variable y
	li $v0, 4
	la $a0, var2
	syscall
	
	#input variable y
	li $v0, 5
	syscall
	
	#save variable y
	move $t4, $v0
	
	#equation stuff
	#multiply
	mul $t5, $t0, $t3  #a*x
	mul $t6, $t1, $t4  #b*y
	#add
	add $t5, $t5, $t6  #a*x + b*y
	#subtract
	sub $t5, $t5, $t2  #a*x + b*y - c
	
	#write answer on the screen	
	li $v0, 4
	la $a0, var3
	syscall
	move $a0, $t5
	li $v0, 1
	syscall
	
	#end program
	li $v0, 10
	syscall
 
        .data
num1:   .word 3
num2:   .word 5
num3:   .word 2
var1:	.asciiz "Enter a number for x: "
var2:	.asciiz "Enter a number for y: "
var3:   .asciiz "Answer: "