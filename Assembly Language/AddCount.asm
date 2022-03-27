########## AddCount ###########
# Author      : Alex Petty
# Program Name: AddCount.asm
# Description : Write an assembly program that will add up integers
#      until a sentinal value of -1 is entered.  Display the count
#      and the sum on the console.  Make sure you have data labels
#      for the output.
#
# Pseudocode
# START AddCount
#  		initialize count
#  		get sentinal value from memory
#  		prompt user to input integer
#  		input integer
# loopStart	adds the integer to the total
#  		IF the sentinal value is used branch to endLoop
#		add the integer to total
#  		add 1 to count
#  		prompt user for integer
#  		input integer
#  		jump back to loopStart
# endLoop 	ends the loop
# 		print total sum of numbers
#  		print total amount of numbers used
#  		end program
# END AddCount
###################################

main:
	#initialize count
	lw $t1, count
	
	#get sentinal value from memory
	lw $t0, endVal
	
	#prompt user to input integer	
	li $v0,4
	la $a0,prompt
	syscall
	
	#input integer
	li $v0,5
	syscall
	move $t3, $v0
	
loopStart:

	#IF the sentinal value is used branch to endLoop
	beq $t3, $t0, endLoop
	
	#add the integer to total
	add $t2, $t2, $t3
	
	#add 1 to count
	add $t1, $t1, 1
	
	#prompt user for integer
	li $v0,4
	la $a0,prompt
	syscall
	
	#input integer
	li $v0,5
	syscall
	move $t3, $v0
	
	#jump back to loopStart
	j loopStart
	
endLoop:

	#print total sum of numbers
	la $a0, sum
	li $v0, 4
	syscall
	move $a0, $t2
	li $v0, 1
	syscall
	
	#print total amount of numbers used
	la $a0, total
	li $v0, 4
	syscall
	move $a0, $t1
	li $v0, 1
	syscall
	
	#end program
	li $v0, 10
	syscall

	.data
prompt: .asciiz "Enter a variable(-1 to quit): " 
endVal: .word -1
count:  .word 0
total:  .asciiz "      Total numbers used: "
sum:    .asciiz "Sum: "