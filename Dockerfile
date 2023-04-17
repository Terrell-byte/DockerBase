FROM mariadb:latest

ENV MYSQL_DATABASE=userDB
ENV MYSQL_USER=myuser
ENV MYSQL_PASSWORD=mypassword
ENV MYSQL_ROOT_PASSWORD=rootpassword

# Copy SQL scripts
COPY createUser.sql /docker-entrypoint-initdb.d/

EXPOSE 3306