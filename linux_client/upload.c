#include "refect.h"
extern struct client_cfg cfg;

int upload_mod(char *filename, int filesize)
{
	int sockfd;
	char buf[BUF_SIZE];
	int nread;
	FILE *fp;
	int len;

	sockfd = connect_server(cfg.res_port);
	if (sockfd < 0)
	{
		printf("Can't connect server, port %d \n", cfg.res_port);
		return -1;
	}

	fp = fopen(filename, "w");
	if (fp == NULL)
	{
		write(sockfd, "FAILURE", 7);
		close(sockfd);
		return 1;
	}
	if (write(sockfd, "SUCCESS", 7) == -1)
	{
		close(sockfd);
		return -1;
	}

	len = 0;
	while((nread = read(sockfd, buf, BUF_SIZE)) > 0)
	{
		fwrite(buf, sizeof(char), nread, fp);
		len += nread;
		if (len >= filesize)
		{
			break;
		}
	}
	fclose(fp);
	close(sockfd);
	return 0;
}

