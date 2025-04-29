cmake_minimum_required(VERSION 3.20)
project(v0_1 C)

set(CMAKE_C_STANDARD 99)

include_directories("C:/Program Files/MySQL/MySQL Connector C 6.1/include")
link_directories("C:/Program Files/MySQL/MySQL Connector C 6.1/lib")
include_directories("C:/Program Files/MySQL/MySQL Connector C 6.1/include")

add_executable(v0_1 main.c)
target_link_libraries(v0_1 mysql)