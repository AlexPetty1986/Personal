########### Arrays.asm  ###########
# Author      : Alex Petty                                  
# Program Name: Arrays.asm
# Due Date    :                                  
# Description : Program will ask user for numbers and put them
#	in an array.  It will then print the array back out
#            
# BEGIN array
#     initialize count
#     initialize eCount
#     jump to array
# array: prompts user for items in array
#     IF count is equal to end count jump to resetCount
#     prompt for a number
#     input number
#     jump back to array
# resetCount: Resets the count back to 0
#     reset the count back to 0
#     jump to loopStart
# loopStart: outputs the variables in the array
#     If count is equal to eCount jump to endloop
#     Display number from the array
#     Add 4 to the counter
#     Jump back to loopStart
# endLoop: end the program
#     end the program
# END Lab1
###############################################
# Registers
#
# $t1 - address of the count
# $t2 - address of the eCount
# 
###############################################

	.text
main:
	#initialize count
	lw $t1, count
	lw $t2, eCount

	#jump to array
	j array

array:	

	#IF count is equal to end count jump to resetCount
	beq $t1, $t2, resetCount
	
	#prompt for a number
	li $v0,4
	la $a0,prompt
	syscall

	#input number
	li $v0,5
	syscall
	sw $v0, list($t1)
	add $t1, $t1, 4

	#jump back to array
	j array

resetCount: #resets the count of the array

	#reset the count back to 0
	sub $t1, $t1, 20
	
	#jump to loopStart
	j loopStart
	
loopStart: #Displays each part of the array

	#If count is equal to eCount jump to endloop
	beq $t1, $t2, endLoop	
	
	#Display number from the array
	lb $a0, list($t1)
	li $v0, 1
    	syscall
    	
    	#Add 4 to the counter
	add $t1, $t1, 4
	
	#Jump back to loopStart
	j loopStart

endLoop:		
	#end program
	li $v0, 10
	syscall 
		
        .data
list:	.space 20	
prompt: .asciiz "Enter a number: "
count:	.word 0
eCount: .word 20