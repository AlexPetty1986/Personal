########### palindrome.asm  ###########
# Author      : Alex Petty                                  
# Program Name: palindrome.asm 
# Due Date    :                                  
# Description : Program determines if the user input is        
#            a palindrome or not.
# BEGIN Lab1
#     initialize yes and no for goAgain
#     prompt the user for a string
# stringSize: finds the size of the string and saves it to $t2
#     load $t2 into $t3
#     IF $t3 equals NULL
#	 branch to endSize
#     add 1 to $t2
#     jump to stringSize
# endSize: modifies the string size so it works
#     subtract 2 from $t2
# loopStart: determines whether the input is a palindrome
#     IF $t1 ends up being greater than $t2
#        branch to isPal
#     load bytes into variables $t3 and $t4
#     IF the two bytes do not equal each other
#	 branch to notPal
#     add 1 to $t1
#     sub 1 from $t2
#     jump to loopStart
# isPal: displays a message saying the word is a palindrome
#     display the is palindrome message
#     jump to goAgain
# notPal: displays a message saying the word is not a palindrome
#     display the not palindrome message
# goAgain: prompts the user if they want to do it again
#     prompt user if they want to go again
#     IF user says yes
#	 branch to main
#     IF user says no
#	 branch to endLoop
# endLoop: ends the loop  
#     end the program
# END Lab1
###############################################
# Registers
#
# $t0 - address of the input string
# $t1 - position at the start of the array
# $t2 - position at the end of the array
# $t3 - byte at the beginning of the string
# $t4 - byte at the end of the string
# $t5 - stores yes for goAgain method
# $t6 - stores no for goAgain method
#
###############################################

	.text
main:
	
	#initialize yes and no for goAgain
	lw $t5, yes
	lw $t6, no
	
	#prompt the user for a string
	li $v0,4
	la $a0,prompt
	syscall

	#input the string from the keyboard
	la $a0,string
	li $v0, 8
	syscall
	
stringSize:

	#load $t2 into $t3
	lb $t3, string($t2)
	
	#IF $t3 equals NULL
	beqz $t3, endSize
	
	#add 1 to $t2
	add $t2, $t2, 1
	
	#jump to arraySize
	j stringSize
	
endSize:

	#subtract 2 from $t2
	sub $t2, $t2, 2
	
loopStart:

	#IF $t1 ends up being greater than $t2
	bgt $t1, $t2, isPal
	
	#load bytes into variables $t3 and $t4
	lb $t3, string($t2)
	lb $t4, string($t1)
	
	#IF the two bytes do not equal each other
	bne $t3, $t4, notPal
	
	#add 1 to $t1
	add $t1, $t1, 1
	
	#sub 1 from $t2
	sub $t2, $t2, 1
	
	#jump to loopStart
	j loopStart
	
isPal:

	#display the is palindrome message
	li $v0,4
	la $a0, pal
	syscall
	j goAgain

notPal:

	#display the not palindrome message
	li $v0,4
	la $a0, nopal
	syscall

goAgain:
	
	#prompt user if they want to go again
	li $v0,4
	la $a0, again
	syscall
	
	#input response from keyboard
	li $v0,5
	syscall
	
	#IF user says yes
	beq $v0, $t5, main
	
	#IF user says no
	beq $v0, $t6, endLoop
	
endLoop:

	#end program
	li $v0, 10
	syscall 
	
        .data
string:	.space  40	
prompt: .asciiz "Enter a string you think is a palindrome   :"
choice: .word 2
yes   : .word 1
no    : .word 0
pal   : .asciiz "That is a pretty cool palindrome dude!!!!!!!\n"
nopal : .asciiz "Sorry my dude, not a palindrome!!!!!!!!!!!!!\n"
again : .asciiz "Want to go again? Yes(1) or No(0)?         :"