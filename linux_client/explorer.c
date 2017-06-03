#include "refect.h"
extern struct client_cfg cfg;
int explorer_mod(char *path)
{
	int sockfd;
    struct dirent *dirent;
    struct stat info;
    struct tm *m_time;
	char *pFilename;
	char *pTmpPath;
	char tmpchr[50];
	char authority[16];
	DIR *dir;
	char send_buf[BUF_SIZE + 1];
	sockfd = connect_server(cfg.res_port);

	if (sockfd < 0)
	{
		printf("Can't connect server, port %d \n", cfg.res_port);
		return -1;
	}
	
	usleep(200000);
	if (stat(path, &info) != 0)
	{
		sprintf(send_buf, "FAILURE\r\n101\r\n"); //不存在
		//FAILURE
		write(sockfd, send_buf, strlen(send_buf));
		close(sockfd);
		return 1;
	}

	//SUCCESS
	if (S_ISREG(info.st_mode))
	{
        sprintf(send_buf, "FAILURE\r\n201\r\n");//存在，不为目录
		//path是普通文件
        write(sockfd, send_buf, strlen(send_buf));
		close(sockfd);
		return 2;
	}
	else if (S_ISDIR(info.st_mode))
	{
        dir = opendir(path);
		if (dir == NULL)
		{
            sprintf(send_buf, "FAILURE\r\n202\r\n");//不可访问
       		write(sockfd, send_buf, strlen(send_buf));
			close(sockfd);
		
			return 3;
		}
		pTmpPath = (char *)malloc(strlen(path) + 3);
		realpath(path, pTmpPath);
        sprintf(send_buf, "SUCCESS\r\n%s\r\n", pTmpPath);
		printf("%s\n", pTmpPath);
        write(sockfd, send_buf, strlen(send_buf));
		free(pTmpPath);
		while ((dirent = readdir(dir)) != 0)
		{
            sprintf(send_buf, "%s\n", dirent->d_name);
			pFilename = (char *)malloc(strlen(dirent->d_name)+ strlen(path)+ 3);
			sprintf(pFilename, "%s/%s", path, dirent->d_name);
            strcpy(authority, "----------");
			if (lstat(pFilename, &info) == 0)
			{
          	  //文件类型
        		if (S_ISDIR(info.st_mode))
				{
                    strcat(send_buf, "1\n");
                    authority[0] = 'd';
				}
           		else if (S_ISREG(info.st_mode))
                {
                    strcat(send_buf, "2\n");
				}
            	else if (S_ISLNK(info.st_mode))
                {
                    strcat(send_buf, "3\n");
                    authority[0] = 'l';
				}
            	else if (S_ISCHR(info.st_mode))
                {
                    strcat(send_buf, "4\n");
                    authority[0] = 'c';
				}
            	else if (S_ISBLK(info.st_mode))
                {
                    strcat(send_buf, "5\n");
                    authority[0] = 'b';
				}
            	else if (S_ISFIFO(info.st_mode))
                {
                    strcat(send_buf, "6\n");
                    authority[0] = 'p';
				}
            	else if (S_ISSOCK(info.st_mode))
                {
                    strcat(send_buf, "7\n");
                    authority[0] = 's';
				}
           		else
				{
                    strcat(send_buf, "8\n");
					//UNKONW TYPE
				}
				snprintf(tmpchr, 24, "%ld\n", info.st_size); //文件大小
				strcat(send_buf, tmpchr);
				//文件权限

				if (S_IRUSR & info.st_mode)
                {
                    authority[1] = 'r';
                }

                if (S_IWUSR & info.st_mode)
                {
                    authority[2] = 'w';
                }

                if (S_IXUSR & info.st_mode)
                {
                    authority[3] = 'x';
                }

                if (S_IRGRP & info.st_mode)
                {
                    authority[4] = 'r';
                }

                if (S_IWGRP & info.st_mode)
                {
                    authority[5] = 'w';
                }

                if (S_IXGRP & info.st_mode)
                {
                    authority[6] = 'x';
                }
                if (S_IROTH & info.st_mode)
                {
                    authority[7] = 'r';
                }
                if (S_IWOTH & info.st_mode)
                {
                    authority[8] = 'w';
                }
                if (S_IXOTH & info.st_mode)
                {
                    authority[9] = 'x';
                }

                if (S_ISGID & info.st_mode)
                {
                    authority[6] = 's';
                }

                if (S_ISUID & info.st_mode)
                {
                    authority[3] = 's';
                }
                strcat(send_buf, authority);
                strcat(send_buf, "\n");
                //文件创建时间
                m_time = gmtime(&(info.st_mtime));
                sprintf(tmpchr, "%4d-%2.2d-%2.2d\n",
                m_time->tm_year + 1900, m_time->tm_mon + 1, m_time->tm_mday);
                strcat(send_buf, tmpchr);
                strcat(send_buf, "\r\n");

            }
			else
			{
				//failure:
				strcat(send_buf, "-1\n-1\nnull\nnull\n\r\n");
			}
			write(sockfd, send_buf, strlen(send_buf));
			free(pFilename);
		}
		closedir(dir);
	}
	else
	{
        sprintf(send_buf, "FAILURE\r\n202\r\n");//不可访问
        write(sockfd, send_buf, strlen(send_buf));
		close(sockfd);
		return 1;
	}
	close(sockfd);
	return 0;

}
