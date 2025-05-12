namespace HospitalSystem.Models
{
    public class CBTree
    {
        private Patient? root; //NULL
        public int count = 0; //Yatan hasta sayısını tutacak.
        public Patient? Find(long tcno){
            return FindT(tcno,root);
        }
        private Patient? FindT(long tcno, Patient? active){
            if(active == null) return null; // Hasta bulunamadı.
            else if (long.Parse(active.TCno)<tcno){
                return FindT(tcno, active.right); //Active düğümü içerisindeki değer aranandan küçükse sağ düğüme gider.
            }
            else if (long.Parse(active.TCno)>tcno){
                return FindT(tcno, active.left); //Active düğümü içerisindeki değer aranandan büyükse sol düğüme gider.
            }
            return active; //Eşit olduğu durumda active düğümü döner.
        }
        public void Add(Patient patient){
            root = InsertTree(patient, root); //Root'a bağlı ağaç güncellenir.
        }
        private Patient? InsertTree(Patient patient, Patient? active){
            if(active == null){
                Patient? newNode = new Patient(patient.Name,patient.TCno,patient.Priority,patient.CaseNo,patient.IsHospitalized);
                newNode.Sickness = patient.Sickness;
                newNode.Speciality = patient.Speciality;
                newNode.AssignedDoctor = patient.AssignedDoctor;
                return newNode;
            }
            if(long.Parse(active.TCno)>long.Parse(patient.TCno)){
                active.left = InsertTree(patient,active.left); //Eklenecek değer daha küçükse aktif düğümün soluna gider. Güncellenen düğüm bağlantısı active'in solu için döndürülür.
                active.Height = 1 + Math.Max(height(active.left), height(active.right)); //Döndürme işlemi olmazsa da yükseklik güncellenir.
                int balance = Balance(active); //Dengesizlik durumu var mı kontrol edilir.
                if(balance > 1){ //Sol tarafta bir dengesizlik var.
                    if(long.Parse(patient.TCno)< long.Parse(active.left.TCno)){ //Sol-sol dengesizliği var.
                        active = rotateRight(active);
                    }
                    else{
                        active.left = rotateLeft(active.left); //Sol-Sağ dengesizliği. Önce aktifin solundaki düğüm sola döndürülür.
                        active = rotateRight(active); //Sonra active sağa döndürülür.
                    }
                }
            }
            else if(long.Parse(active.TCno)<long.Parse(patient.TCno)){
                active.right = InsertTree(patient,active.right); //Eklenecek değer daha büyükse aktif düğümün sağına gider. Güncellenen düğüm bağlantısı active'in sağı için döndürülür.
                active.Height =1 + Math.Max(height(active.left), height(active.right));//Döndürme işlemi olmazsa da yükseklik güncellenir.
                int balance = Balance(active);
                if(balance < -1){ //Balance metodu sol yükseklik - sağ yükseklik yapıyordu o yüzden -1'den küçükse sağda dengesizlik olur.
                    if(long.Parse(patient.TCno) > long.Parse(active.right.TCno)){ //Sağ-Sağ dengesizliği.
                        active = rotateLeft(active);
                    }
                    else{
                        active.right = rotateRight(active.right); //Sağ-sol dengesizliği. Önce aktif düğümün sağ çocuğu sağa döndürülür ve sağ-sağ dengesizliği elde edilir.
                        active = rotateLeft(active); //Daha sonra aktif düğüm sola döndürülür ve dengesizlik çözülür.
                    }
                }
            }
            //Döndürme işlemleri recursive olarak ekleme yapıldıktan sonra ilk çağrıma geri dönülürken her düğüm için yapılır.
            return active; //Eşit bir değer varsa tekrar eklemez. Değişim yoksa kendi adresini önceki düğüme döndürür. Herhangi bir ekleme işleminde dengesizlik oluştuysa ondan önceki çağrıya dönülürken dengesizlikler rotate ile düzeltiliri ve burada active'in yeni konumu döndürülür.
        }
        public void remove(long tcno){ 
            root = remove(tcno, root);
        }
        private Patient? remove(long tcno, Patient? active){ //Overload işlemi yaptım.
            if (active == null) return null; //Ağaç boş veya aranan değer yok.
            if (tcno < long.Parse(active.TCno)){ //Aranan değer aktif düğümden küçükse sola gider.
                active.left = remove(tcno, active.left);
            }
            else if(tcno > long.Parse(active.TCno)){ //Aranan değer aktif düğümden büyükse sağa gider.
                active.right = remove(tcno, active.right);
            }
            else{ //Aranan değer aktif düğümle eşitse
                if(active.right != null && active.left != null) //İki çocuğu varsa
                {
                    Patient? MaxNode = Max(active.left);
                    active.TCno = MaxNode.TCno;
                    active.Name = MaxNode.Name;
                    active.Priority = MaxNode.Priority;
                    active.CaseNo = MaxNode.CaseNo;
                    active.IsHospitalized = MaxNode.IsHospitalized;
                    active.left = remove(long.Parse(active.TCno), active.left);
                }
                else
                {
                    if(active.left == null){ //Sağ çocuk varsa
                        return active.right; //Silinecek düğüm sağ çocuklar değiştirilir.
                    }
                    else if (active.right == null){
                        return active.left; //Silinecek düğüm sol çocukla değiştirilir.
                    }
                    return null;
                }
            }
            active.Height = 1 + Math.Max(height(active.left), height(active.right));
            int balance = Balance(active);
            if(balance > 1 && Balance(active.left) >= 0 ){//Sol-Sol dengesizliği vardır.
                return rotateRight(active);
            }
            if(balance > 1 && Balance(active.left) < 0){ //Sol-Sağ dengesizliği vardır.
                active.left = rotateLeft(active.left);
                active = rotateRight(active);
            }
            if(balance < -1 && Balance(active.right) <= 0){ //Sağ-Sağ dengesizliği vardır.
                active = rotateLeft(active);
            }
            if(balance < -1 && Balance(active.right) > 0){ //Sağ-Sol dengesizliği vardır.
                active.right = rotateRight(active.right);
                active = rotateLeft(active);
            }
            return active;
        }
        private Patient? rotateRight(Patient? parent){
            if (parent == null || parent.left == null)
                return parent;
            Patient? lchild = parent.left;
            parent.left = lchild.right; //Parent'tan küçük sağ çocuktan büyük olan bir değer varsa parent'ın soluna atanır.
            lchild.right = parent; //Parent ile child yer değiştirilir.
            parent.Height = 1 + Math.Max(height(parent.left), height(parent.right));
            lchild.Height = 1 + Math.Max(height(lchild.left), height(lchild.right));
            return lchild; //Yeni parent döndürülür.
        }
        private Patient? rotateLeft(Patient? parent){
            if (parent == null || parent.right == null)
                return parent;
            Patient? rchild = parent.right;
            parent.right = rchild.left; //Parenttan büyük çocuktan küçük bir değer varsa parent'ın sağına atanır.
            rchild.left = parent; //Parent ile child yeri değişir.
            parent.Height = 1 + Math.Max(height(parent.left), height(parent.right)); 
            rchild.Height = 1 + Math.Max(height(rchild.left), height(rchild.right));
            return rchild; //Yeni parent döndürüldü. 
        }
        private Patient? Max(Patient? active){
            if (active == null) return null;
            if (active.right == null) return active;
            return Max(active.right);
        }

        private int Balance(Patient? active){
            if(active == null)
                return 0;
            return height(active.left) - height(active.right); //Negatif veya pozitif çıkmasına göre dengesizliğin sol alt ağaçta mı sağ alt ağaçta mı olduğunu gösterir.
        }
        private int height(Patient? active){
            return active?.Height ?? 0;
        }
    }
}