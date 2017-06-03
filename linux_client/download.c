#include "refect.h"
extern struct client_cfg cfg;

int download_mod(char *filename)
{
	int sockfd;
	char buf[BUF_SIZE];
	int nread;
	int filesize;
	FILE *fp;
	int len;

	sockfd = connect_server(cfg.res_port);
	if (sockfd < 0)
	{
		printf("Can't connect server, port %d \n", cfg.res_port);
		return -1;
	}

	fp = fopen(filename, "r");
	if (fp == NULL)
	{
		write(sockfd, "FAILURE\n", 8);
		close(sockfd);
		return 1;
	}
	fseek(fp, 0l, SEEK_END);
	filesize = ftell(fp);
	fseek(fp, 0l, SEEK_SET);
	snprintf(buf, BUF_SIZE - 1, "SUCCESS\n%d\n", filesize);
	write(sockfd, buf, strlen(buf));

	nread = read(sockfd, buf, BUF_SIZE - 1);
	buf[nread] = '\0';
	if (strcmp(buf, "SUCCESS") != 0)
	{
		close(sockfd);
		fclose(fp);
		return 2;
	}
	while (!feof(fp))
	{
		nread = fread(buf, sizeof(char), BUF_SIZE, fp);
		write(sockfd, buf, nread);
	}

	close(sockfd);
	fclose(fp);
	return 0;

}

