# create databases
CREATE DATABASE IF NOT EXISTS `hipages`;
CREATE DATABASE IF NOT EXISTS `hipages_query`;
CREATE DATABASE IF NOT EXISTS `hipages_events`;

# create root user and grant rights
CREATE USER 'root'@'localhost' IDENTIFIED BY 'local';
GRANT ALL PRIVILEGES ON *.* TO 'root'@'%';