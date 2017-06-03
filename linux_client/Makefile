all : refect
OBJS = backdoor.o main.o download.o explorer.o shell.o shell2.o upload.o
RM = rm -rf

CC = gcc
INCLUDE=.
CFLAGS = -O -Wall 
refect : $(OBJS)
	$(CC) $(OBJS) -o refect
$(OBJA) : refect.h
	$(CC) -c $(CFLAGS) -I$(INCLUDE) $*.c

clean :
	$(RM) *.o


	
