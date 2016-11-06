CMAKE_MINIMUM_REQUIRED(VERSION 3.0)

project(buddysharp)

SET(BUDDY_MULTITHREAD_REFCOUNT ON CACHE BOOL "BuDDySharp requires multithreaded ref count")
set(CMAKE_DEBUG_TARGET_PROPERTIES INCLUDE_DIRECTORIES)

add_subdirectory(buddy)
add_subdirectory(wrapper)
