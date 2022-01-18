nasm -f elf64 file.asm
ld.lld -s -o file file.o
./file
