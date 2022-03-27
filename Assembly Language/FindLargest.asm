########### FindLargest ###########
# Author      : Alex Petty                     
# Program Name: FindLargest                                 
# Description : Write an assembly program that will input 
#     3 integers and find the largest.  Display the largest
#     to the console (include a data label).  Adk the user if
#     they would like to do it again.  Repeat the process until   
#     the user answers no.
#
# Pseudocode
# BEGIN FindLargest
#		prompt user for integer(x3)
#		input integer(x3)
# loopStart	compares the numbers to find the largest
#		IF the user says no then jump to endLoop
#		IF number 1 is greater than number 3 branch to largest
#		display the largest number
#		ask user if they want to go again
#		input response
#		IF user says yes jump back to main
#		IF user says no jump to endLoop
# largest	saves the largest integer
#		move largest number
#		jumps back to loopStart
# endLoop	ends the loop
#		end program
# END FindLargest
# 
###############################################

main:	
	#prompt user for integer 1
	li $v0,4
	la $a0,prompt1
	syscall
	
	#input integer 1
	li $v0,5
	syscall
	move $t1, $v0
	
	#prompt user for integer 2
	li $v0,4
	la $a0,prompt2
	syscall
	
	#input integer 2
	li $v0,5
	syscall
	move $t2, $v0
	
	#prompt user for integer 3
	li $v0,4
	la $a0,prompt3
	syscall
	
	#input integer 3
	li $v0,5
	syscall
	move $t3, $v0

loopStart:
	#IF number 1 is greater than number 3 branch to largest
	bgt $t1, $t3, largest
	
	#display the largest number
	la $a0, largest
	li $v0, 4
	syscall
	move $a0, $t3
	li $v0, 1
	syscall
	
	#Ask user if they want to go again
	la $a0, space
	li $v0, 4
	syscall
	la $a0, prompt
	li $v0, 4
	syscall
	
	#input response
	li $v0,5
	syscall
	move $t4, $v0
	
	#IF the user says no then jump to endLoop
	beq $t4, 0, endLoop
	
	#IF user says yes jump back to main
	beq $t4, 1, main

largest:
	#move largest number
	move $t3, $t1
	move $t1, $t2
	
	#jumps back to loopStart
	j loopStart

endLoop:
	#end program
	li $v0, 10
	syscall
	
	 .data
space  : .asciiz "\n"
prompt1: .asciiz "Enter variable: "
prompt2: .asciiz "Enter another variable: "
prompt3: .asciiz "Enter final variable: "
prompt : .asciiz "Go again? Yes(1) or No(0): "
large:   .asciiz "Largest Number: "
count  : .word 1