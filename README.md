# Dijkstra-CSharp
Implementation of Dijkstra's algorithm in C#, just for learning purpose

# Usage
- Start visual studio, open the .sln file
- Build the solution
- Execute the tests

# Implementions

### Exemple Graph

````
             2        8       
         A ----- B ------ G   |  Distance between vertex A and vertex B : 2
         | \     | \      |3  |  Distance between vertex A and vertex C : 5
         |  \    | 2\   1 |   |  Distance between vertex A and vertex D : 3
        5|  3\  4|    E - F   |  Distance between vertex A and vertex E : 4
         |    \  | 3/         |  Distance between vertex A and vertex F : 5
         |     \ | /          |  Distance between vertex A and vertex G : 8
         C ----- D ------ H   |  Distance between vertex A and vertex H : 4
             3        1         
````

**Shortest distances between each point:**

|   | A | B | C | D | E | F | G | H |
|:---:|:---:|:---:|:---:|:---:|:---:|:---:|:---:|:---:|
| **A** | 0 | 2 | 5 | 3 | 4 | 5 | 8 | 4 |
| **B** | 2 | 0 | 7 | 4 | 2 | 3 | 6 | 5 |
| **C** | 5 | 7 | 0 | 3 | 6 | 7 |10 | 4 |
| **D** | 3 | 4 | 3 | 0 | 3 | 4 | 7 | 1 |
| **E** | 4 | 2 | 6 | 3 | 0 | 1 | 4 | 4 |
| **F** | 5 | 3 | 7 | 4 | 1 | 0 | 3 | 5 |
| **G** | 8 | 6 |10 | 7 | 4 | 3 | 0 | 8 |
| **H** | 4 | 5 | 4 | 1 | 4 | 5 | 8 | 0 |

### Adjacency Matrix
- Easy to understand
- Easy to implement
- Algorithm complexity *O(N²)*

### Adjacency List
- More complexe to implement
- Use a custom implementation of a MinHeap
- Algorithm complexity *O(E Log N)*

