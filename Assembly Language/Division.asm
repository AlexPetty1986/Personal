########### helloIO.asm  ###########
# Author      : Alex Petty                                  
# Program Name: division.asm                                   
# Description : Program which calculates an average using integer
#               division.  Average should be rounded to nearest int        
#            
# BEGIN Lab1
#     get 3 numbers from the console
#     find the sum of the numbers
#     calculate the average rounded to the nearest integer
#     display the sum and average to the console
#     end the program
# END Lab1
###############################################

	.text
main:

	#Prompt for variable a
	li $v0,4
	la $a0,prompt1
	syscall
	#input variable a
	li $v0,5
	syscall
	#save variable a
	move $t0, $v0
	#Prompt for variable b
	li $v0,4
	la $a0,prompt2
	syscall
	#input variable b
	li $v0,5
	syscall
	#save variable b
	move $t1, $v0
	#Prompt for variable c
	li $v0,4
	la $a0,prompt3
	syscall
	#input variable c
	li $v0,5
	syscall
	#save variable c
	move $t2, $v0
	
	#find the sum of the numbers
	add $t0, $t0, $t1
	add $t0, $t0, $t2
	
	#calculate the average rounded to the nearest integer
	div $t3, $t0, 3
	mflo $t3

	
	#display the sum and average to the console
	#display sum
	la $a0, sum
	li $v0, 4
	syscall	
	move $a0, $t0
	li $v0, 1
	syscall
	
	#display average
	la $a0, avg
	li $v0, 4
	syscall
	move $a0, $t3
	li $v0, 1
	syscall
	#end program
	li $v0, 10
	syscall
 
        .data
sum:	.asciiz "Sum: "
avg:	.asciiz " Average: "
prompt1:.asciiz "Enter a number: "
prompt2:.asciiz "Enter another number: "
prompt3:.asciiz "Enter one more number: "