########### funct2.asm  ###########
# Author      : Alex Petty                                  
# Program Name: funct2.asm
# Due Date    : 12/7/2020                              
# Description : Write a function "hexint" that takes the address
#	of an ascii character string in $a0. The string will 
#	represent a number in hexadecimal and will only contain 
#	'0' to '9' and 'A' to 'F'. Return the actual number in 
#	the register  $v0.  Remember that the most significant nibble
#	will be first in the string.
#
# BEGIN funct2
#       Call the hex string from memory
#	Call hexint function
#	Print hex value on screen
# exit: ends the program
#	End program
# END funct2.a
#####################################
# BEGIN hexint: converts the hex value to a decimal value
#	initialize 16 and 1 for converting char to int
#	pull a char from the string
#	IF char value is less than 64 branch to convert
#	subtract 55 from char value
# addtime: adds up the total for the hex string
#	Add 1 to the counter
#	IF counter is less than 3 branch to counter
#	add converted char value to the total
#	IF counter is not equal to 3 branch to hexint
#	jump back to the main program
# first: jump to this if at the first char in the string
#	convert char value into a decimal value	
#	add converted char value to the total
#	jump back to hexint
# second: jump to this if at the second char in the string
#	convert char value into a decimal value	
#	add converted char value to the total
#	jump back to hexint
# counter: determines where in the counter you are
#	IF count is equal to 1 branch to first
#	IF count is equal to 2 branch to second
# convert: converts any letters into decimal values
#	sub 48 from the char value
#	jump to addtime
# END hexint
####################################
# Registers
#
# $t0 - used to keep count for the cahracter string
# $t1 - holds the char value from the character string
# $t2 - holds the value 16 for converting hex to decimal
# $t3 - holds the value 1 for converting hex to decimal
# $t4 - holds a value for the final conversion of the hex value
# $t5 - holds a value for the final conversion of the hex value
# $a0 - used to store the converted character string
# $v0 - holds the converted character string
#
####################################

	.text
main:
	
	#Call the hex string from memory
	la $a0, ans
	li $v0, 4
	syscall
	la $a0, str
	
	#Call hexint function
	jal hexint
	
	#Print hex value on screen
	move $a0, $v0
	li $v0, 1
	syscall
	
	#System call to print
	la $a0, endl
	li $v0, 4
	syscall
	
exit:
	#End program
	li $v0, 10
	syscall	

#####################################################
hexint:

	#initialize 16 and 1 for converting char to int
	li $t2, 16
	li $t3, 1
	
	#pull a char from the string
	lb $t1, str($t0)
	
	#IF char value is less than 64
	blt $t1, 64, convert
	
	#subtract 55 from char value
	sub $t1, $t1, 55
	
addtime:

	#Add 1 to the counter
	add $t0, $t0, 1
	
	#IF counter is less than 3 branch to counter
	blt $t0, 3, counter
	
	#add converted char value to the total
	add $v0, $v0, $t1
	sub $v0, $v0, 4
	
	#IF counter is not equal to 3 branch to hexint
	bne $t0, 3, hexint

	#jump back to the main program
	jr $ra
	
first:

	#convert char value into a decimal value
	mul $t4, $t2, $t2
	mul $t1, $t1, $t4
	
	#add converted char value to the total
	add $v0, $v0, $t1
	
	#jump back to hexint
	j hexint
	
second:

	#convert char value into a decimal value
	mul $t5, $t2, $t3
	mul $t1, $t1, $t5
	
	#add converted char value to the total
	add $v0, $v0, $t1

	#jump back to hexint
	j hexint
	
counter:
	
	#IF count is equal to 1
	beq $t0, 1, first
	
	#IF count is equal to 2
	beq $t0, 2, second
	
convert:

	#sub 48 from the char value
	sub $t1, $t1, 48
	
	#jump to addtime
	j addtime

#####################################################

	.data
str:	.asciiz "7A8"
ans:	.asciiz "Number is = "
endl:	.asciiz "\n"