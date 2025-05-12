namespace HospitalSystem.Models
{
    public class CaseAVLTree
    {
        Case? root; //Başlangıç null.
        public void Add(int caseno, string name, string speciality)
        {
            root = InsertTree(caseno,name,speciality,root); //Ağaç
        }
        private Case? InsertTree(int caseno, string name, string speciality, Case? active) //CaseNo, name ve speciality alacak. Bunları ağaca ekleyecek. Eklemeyi CaseNo'ya göre yapacak.
        {
            Case? newCase = new Case(caseno, name, speciality);
            if (active == null)
            {
                return newCase;
            }
            if (active.CaseNo > caseno)
            {
                active.left = InsertTree(caseno, name, speciality, active.left);
                active.Height = height(active);
                int balance = Balance(active);
                if(balance > 1){
                    if(caseno < active.CaseNo){
                        active = rotateRight(active);
                    }
                    else{
                        active.left = rotateLeft(active.left);
                        active = rotateRight(active);
                    }
                }
            }
            else if (active.CaseNo < caseno)
            {
                active.right = InsertTree(caseno,name,speciality,active.right);
                active.Height = height(active);
                int balance = Balance(active);
                if(balance < -1){
                    if(caseno > active.right.CaseNo){ //Sağ-Sağ
                        active = rotateLeft(active);
                    }
                    else{
                        active.right = rotateRight(active.right);
                        active = rotateLeft(active);
                    }
                }
            }
            return active;
        }
        private int height(Case? active){
            if(active == null) return 0;
            return 1+Math.Max(height(active.left),height(active.right));
        }
        private int Balance(Case? active){
            if(active == null) return 0;
            return height(active.left) - height(active.right);
        }
        private Case? rotateLeft(Case? active)
        {
            if (active == null || active.right == null) return active;
            Case? rchild = active.right;
            active.right = rchild.left;
            rchild.left = active;
            active.Height = height(active);
            rchild.Height = height(rchild);
            return rchild;
        }
        private Case? rotateRight(Case? active){
            if (active == null || active.left == null) return active;
            Case? lchild = active.left;
            active.left = lchild.right;
            lchild.right = active;
            active.Height = height(active);
            lchild.Height = height(lchild);
            return lchild;
        }
        public Case? Find(int caseno){
            return FindT(caseno, root);
        }
        private Case? FindT(int caseno, Case? root){
            if (root == null) return root;
            if(caseno < root.CaseNo){
                return FindT(caseno, root.left);
            }
            else if(caseno > root.CaseNo){
                return FindT(caseno,root.right);
            }
            return root;
        }
    }
}