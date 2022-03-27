
########### Swap chars ###########
# Author      : Alex Petty                             
# Program Name: Loop.asm                                  
# Description : This program will take a string
#	inputted by the user.  It will then swap
#	the bytes in the string by like moving
#	the first byte with the second byte
# Pseudocode
# BEGIN Swap Chars
#	Initialize $t1 to 0
#       Prompt user for string
# loopStart   swaps locations of the two bytes
#	Get a bytes from the string
#       IF at end of the string branch to endStr
#       add 1 to the count
#       get the next char in the string
#       swap the 2 chars by writing them back to the original string
#       add 2 to the count 
#       Jump back to loopStart
# strEnd      Ends the loop
#       print modified string
#       end program
#
###############################################
# Registers
#
# $t1 - address of the count
# $t3 - first byte being swapped
# $t4 - second byte being swapped
# 
###############################################

main:

	#Initialize $t1 to 0
	lw $t1, count
	
	#Prompt user for string
	li $v0,4
	la $a0,prompt
	syscall

	#Input string from the console
	la $a0, input
	li $v0, 8
	syscall
	
loopStart: 
	
	#Get a char from the string
	lb $t3, input($t1)
	
	#IF at end of the string branch to endStr
	beqz $t3, strEnd
	
	#add 1 to count
	add $t1, 1
	
	#get the next char in the string
	lb $t4, input($t1)
	
	#swap the 2 chars by writing them back to the original string
	sb $t3, input($t1)
	sub $t1, 1
	sb $t4, input($t1)
	
	#add 2 to the count
	add $t1, $t1, 2
	
	#Jump back to loopStart
	j loopStart

strEnd:
	#print modified string
	la $a0, input
	li $v0,4
	syscall

	#end program
	li $v0, 10
	syscall
	
	.data
	
prompt: .asciiz "Enter string: "
input:  .space 80
count:  .word 0