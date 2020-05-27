#include <iostream>
using namespace std;
class Node {
public:
    double data;
    Node* next;
    Node* previous;
};

void AddFirst(Node** head, double new_element) {

    Node* new_node = new Node();
    new_node->data = new_element;

    new_node->next = (*head);
    new_node->previous = NULL;

    if ((*head) != NULL)
        (*head)->previous = new_node;
    (*head) = new_node;
}
void Add(Node** head_ref, double new_data)
{

    Node* new_node = new Node();

    Node* last = *head_ref;


    new_node->data = new_data;

    new_node->next = NULL;

    if (*head_ref == NULL)
    {
        new_node->previous = NULL;
        *head_ref = new_node;
        return;
    }

    while (last->next != NULL)
        last = last->next;

    last->next = new_node;

    new_node->previous = last;
    return;
}
int Size(Node* node) {
    int res = 0;
    while (node != NULL) {
        res++;
        node = node->next;
    }
    return res;
}
double Average(Node* node) {
    double av = 0;
    int size = Size(node);
    while (node != NULL) {
        av += node->data;
        node = node->next;
    }
    av = av / size;
    return av;
}
void Delete(class Node** head_ref, Node* del) {
    if (*head_ref == NULL || del == NULL)
        return;


    if (*head_ref == del)
        *head_ref = del->next;

    if (del->next != NULL)
        del->next->previous = del->previous;

    if (del->previous != NULL)
        del->previous->next = del->next;

    free(del);

    return;
}

double FindMax(Node** head_ref) {
    class Node* max, * temp;
    temp = max = *head_ref;
    while (temp != NULL) {
        if (temp->data > max->data)
            max = temp;
        temp = temp->next;
    }
    return max->data;
}
void DeleteAfterMax(Node** head_ref) {
    double max = FindMax(head_ref);
    Node* ptr = *head_ref;
    Node* next;
    while (ptr->data != max) {
        next = ptr->next;
        ptr = next;
    }
    next = ptr->next;
    ptr = next;
    while (ptr != NULL) {
        next = ptr->next;
        
        Delete(head_ref, ptr);
        ptr = next;
    }
}


int ELementsLesserThanAvg(Node* node, double av) {
    int count = 0;

    while (node != NULL) {
        if (node->data < av)
            count++;
        node = node->next;
    }
    return count;
}

void printList(Node* node)
{
    Node* last = new Node();
    cout << "\nTraversal in forward direction \n";
    while (node != NULL)
    {
        cout << " " << node->data << " ";
        last = node;
        node = node->next;
    }

    /*cout << "\nTraversal in reverse direction \n";
    while (last != NULL)
    {
        cout << " " << last->data << " ";
        last = last->prev;
    }*/
}




int main()
{
    Node* head = NULL;
    AddFirst(&head, 6);
    AddFirst(&head, 8);
    AddFirst(&head, 12);
    AddFirst(&head, 15);
    AddFirst(&head, 17);
    AddFirst(&head, 6);
    printList(head);
    cout << endl;
    double av = Average(head);
    cout << "Average:" << av << endl;
    cout << "Elements lesser than average: " << ELementsLesserThanAvg(head, av) << endl;
    // cout << findMax(&head);
    DeleteAfterMax(&head);
    printList(head);
}