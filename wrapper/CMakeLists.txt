set(CMAKE_SKIP_RPATH TRUE)

add_library(buddysharp_extension SHARED
	wrapper.c
)
target_link_libraries(buddysharp_extension PUBLIC buddy_shared)
set_target_properties(buddysharp_extension PROPERTIES WINDOWS_EXPORT_ALL_SYMBOLS TRUE)
