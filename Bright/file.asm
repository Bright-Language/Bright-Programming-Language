section .text
	global _start
_start:
	push rbp
	mov rbp, rsp
	sub rsp, 24
	mov DWORD [rbp-4], 5
	mov QWORD [rbp-12], 'str'
	mov DWORD [rbp-16], 3
	mov	eax,1
	int	0x80
.LC12:
	db 'str'