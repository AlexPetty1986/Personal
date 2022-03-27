########### Mask and Rotate ###########
# Author      : Alex Petty                             
# Program Name: MaskAndRotate.asm                                  
# Description : This program will extract word and
#	then put it in a register.  It will mask the last
#	8 bits of the word and then print them back on screen.
#	It will then rotate to the right by 8 bits and then
#	mask and print them back on screen till the specified amount
#	is reached.
#
# Pseudocode
# BEGIN Mask and Rotate
#	initialize count to 0
#	load word into register
#	mask the last eight bits
#	print the isolated bits in ASCII format
# loopStart: rotates the register by 8 bits
#       IF count equals 3 jump to endLoop
#	rotate the register 8 bits to the right
#	mask the last eight bits
#	print the isolated bits in ASCII format
#	add 1 to count
#	jump to loopStart
# endLoop: ends the program
#	end program
# END Mask and Rotate
###############################################
# Registers
#
# $t1 - keeps the count for the loop
# $t2 - stores the word loaded into it
# $a0 - stores the eight bits that are isolated
# 
###############################################

main:

	#initialize count to zero
	li $t1, 0
	
	#load word into register
	li $t2, 0x44434241
	
	#isolate the last eight bits
	andi $a0, $t2, 0xff
	li $v0, 11
	syscall

loopStart:	

	#IF count equal to 3 branch to endLoop
	beq $t1, 3 endLoop
	
	#rotate the register 8 bits to the right
	ror $t2, $t2, 8
	
	#isolate the last eight bits
	andi $a0, $t2, 0xff
	li $v0, 11
	syscall
	
	#add 1 to count
	add $t1, $t1, 1
	
	#jump to loopStart
	j loopStart

endLoop:

	#end program
	li $v0, 10
	syscall
		
	.data