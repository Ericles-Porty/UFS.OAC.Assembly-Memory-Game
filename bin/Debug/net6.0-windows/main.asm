.data
	localArq: .asciiz "C:/Users/Ericles/Desktop/Memory/bin/Debug/net6.0-windows/Combination.txt"
	myarray:
		.align 2
		.space 24
		
.text
	move $t0, $zero #Indice do array
	move $t1, $zero	# valor a ser colocado no array
	move $t3, $zero	
	li $t4, 1
	
	li $t2, 5	#tamanho do array
	li $s2, 12
	addi $t5, $zero, 0
	
	#la $s1, ent
	
	jal for
	
	#Escrita
	li $v0, 13           # Solicita a abertura do arquivo
	la $a0, localArq         # Endere�o do arquivo no registrador $a0
	li $a1, 1            # para leitura�carrega 0 e para escrita 1
	syscall
	move $s0, $v0 
	jal loop
	
	li $v0, 10
	syscall

	for:
		beq $t0, $t2, saifor
			
			
			
			#Gerador de numero aleat�rio
			li $a1, 10		
			li $v0, 42		
			syscall	
			
			li $t6,0
			bge $t6,$a0, saifor2
			move $t1, $a0
			addi $t1, $t1, 48
			sb $t1, myarray($t0)
			addi $t0, $t0, 1
			#addi $t1, $t1, 1	
			
			j for
			
			saifor2:
				j for

	loop:
		bge  $t3, $t2 saida		
		li $v0, 15           # Ler o conte�do do arquivo que est� referenciado em $a0 
		move $a0, $s0
		
		la $a1, myarray($t5)   #conteudo($t3)       # Registrador que armazena o conte�do 
		addi $t5, $t5, 1
		move $a2, $t4        # Numeros de bytes que referenciam o tamanho do buffer
		syscall  	#Leitura realizada
		
		addi $t3, $t3, 1
		j loop
	saida:
		li $v0, 16           
		move $a0, $s0        
		syscall 
		jr $ra

		
			
			
			
	
