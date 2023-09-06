
const translations = {
    en: {
        title: 'B.TECH',
        delivery: 'My delivery area: Cairo',
        sell: 'Sell on B.TECH',
        call: 'Call 19966',
        english: 'English',
        arabic: 'عربي',
        categories:'Categories',
        everydayDeals:'Everyday Deals',
        Welcome:'Welcome',
        cart:'Cart',
        placeholder:'Search For Products or Brands',
        supp:'Call Support 19966',
        warranty:'B.TECH warranty',
        ultra:'Ultra',
        ariston:'Ariston',
        indesit:'Indesit',
        babyliss:'Babyliss',
        miele:'Miele',
        WorkWithUs: 'Work With Us',
        about : 'About' ,
       
        services:'B.TECH services',
        minicash:'Minicash',
        connect:'Connect With Us',
        Download:'Download the B.TECH app',
        Trending:'Trending now',
        mobile:'Mobile',
        braunOffers:'Braun offers',
        tVs:'TVs',
        accessories:'Accessories',
        oppo:'Oppo',
        samsung:'Samsung',
        apple:'Apple',
        mobilesTablets:'Mobiles & Tablets',
        tVs:'TVs',
        smallHome:'Small Home Appliances',
        largeHome:'Large Home Appliances',
        laptopsPCs:'Laptops & PCs',
        personalCare:'personal Care',
        electronics:'Electronics',
        gaming:'Gaming',
        sports:'Sports',
        titleLogin:'Customer Login',
        titleWelcomeBk:'Welcome Back!',
        startedPharse:`Let's get started!`,
        loginhint:`Use your mobile number to sign in or sign up.`,
        inputLabel:'Mobile Number',
        emailSignInLink:'or sign in with email',
        Privacy:'By continuing, you agree to our Privacy Policy and Terms of Use',
        continueBtn:'Continue',
        SignInhint:'Sign in to your B.TECH account and explore our latest exclusive offers',
        Login: 'Login',
        Email: 'Email',
        Password: 'Password',
        SignOut: 'Sign Out',
        FirstName: 'First Name',
        LastName: 'Last Name ',
        Address: 'Address',
        PhoneNumber: 'Phone Number',
        Register: 'Register',
        NewUser: 'New User',
        AddToCart: 'Add To Cart',
        Description: 'Description : ',
        Quantity: 'Quantity :',
        Price: 'Price :',
        Name: 'Name : ',
        NewUser: 'New User',
        account : 'My Acount'


    },
    ar: {
        title: 'بي تك',
        delivery: 'منطقة التوصيل: القاهرة',
        sell: 'بيع على بـي تك ',
        call: 'اتصل على 19966',
        english: 'English',
        arabic: 'عربي',
        categories:'فئات',
        everydayDeals:'عروض كل يوم',
        Welcome: ' مرحبا',
        Login : 'تسجيل دخول',
        cart:'مشترياتى',
        placeholder:'ابحث في المنتجات أو الماركات',
        supp:'اتصل بنا 19966',
        warranty:'بضمان بي تك',
        ultra:'الترا',
        ariston:'أريستون',
        indesit:'إنديست',
        babyliss:'بيبي ليس',
        miele:'ميلا',
        WorkWithUs:'اعمل معنا',
        about:'عن بي.تك',
        services:'خدمات بي.تك',
        minicash:'تقسيط الميني كاش',
        connect:'تواصل معنا',
        Download:'نزّل تطبيق بي.تك',
        Trending:'عليه طلب',
        mobile:'الموبايل',
        braunOffers:'عروض براون',
        tVs:'تلفزيونات',
        accessories:'اكسسوارات',
        oppo:'أوبو',
        samsung:'سامسونج',
        apple:'ابل',
        mobilesTablets:'موبايل وتابلت',
        tVs:'تلفزيونات',
        smallHome:'أجهزة منزلية صغيرة',
        largeHome:'أجهزة منزلية كبيرة',
        laptopsPCs:'لابتوب وكمبيوتر',
        personalCare:'أدوات العناية الشخصية',
        electronics:'الكترونيات',
        gaming:'العاب',
        sports:'رياضة',
        titleLogin:'تسجيل دخول',
        titleWelcomeBk:'!أهلا بيك',
        startedPharse:`!يلا نبدأ`,
        loginhint:`استخدم رقم موبايلك لتسجيل الدخول أو إنشاء حساب.`,
        inputLabel:'رقم الموبايل',
        emailSignInLink:'أو أدخل البريد الإلكتروني',
        Privacy:'بالمتابعة، فأنت توافق على سياسة الخصوصية و شروط الاستخدام',
        continueBtn:'متابعة',
        SignInhint: 'ادخل على حسابك في بـي تك وشوف آخر عروضنا الحصرية',
        Email: 'البريد الاليكتروني',
        Password: 'كلمة السر',
        SignOut: 'خروج',
        FirstName: 'الاسم الاول',
        LastName: 'اسم العائلة',
        Address: 'العنوان',
        PhoneNumber: 'رقم الهاتف',
        Register: 'تسجيل',
        NewUser: 'مستخدم جديد',
        Login: 'دخول',
        AddToCart: 'أضف الي مشترياتي',
        Description: ' : الوصف',
        Quantity: ' : الكمية',
        Price: ': السعر',
        Name: ': اسم المنتج',
        NewUser :'مستخدم جديد' ,
    
        account: 'حسابي'

    }
}

let slideshowTimeout;
let languageselected = document.querySelector('select')
languageselected.addEventListener('change', (event) => {
    setLanguage(event.target.value)
    localStorage.setItem("lang", event.target.value)
})

document.addEventListener('DOMContentLoaded', () => {
    const lang = localStorage.getItem("lang");
    setLanguage(lang)
    document.querySelector('select').value = lang
});
const setLanguage = (language) => {
    const elements = document.querySelectorAll("[data-lng]")
    elements.forEach((element) => {
        const translateKey = element.getAttribute("data-lng")
        element.textContent = translations[language][translateKey]
    });

    const searchInput = document.getElementById("searchInput");
    searchInput.placeholder = translations[language].placeholder;
    //const EmailInput = document.getElementById("Email");
    //EmailInput.placeholder = translations[language].placeholder;
    //const PassInput = document.getElementById("Password");
    //PassInput.placeholder = translations[language].placeholder;

    document.dir = language === "ar" ? 'rtl' : 'ltr';
    clearTimeout(slideshowTimeout);
    showSlides(language)
}

const enImageUrls = [
    { url: "../Images/ONE.webp", href: "" },
    { url: "../Images/second.webp", href: "" },
    { url: "../Images/third.webp", href: "" },
    { url: "../Images/four.webp", href: "" },
    { url: "../Images/five.webp", href: "" },
    { url: "../Images/six.webp", href: "" },
    { url: "../Images/seven.webp", href: "" },
    { url: "../Images/eight.webp", href: "" },
];

const arImageUrls = [
    { url: "../Images/AONE.webp", href: "" },
    { url: "../Images/Atwo.webp", href: "" },
    { url: "../Images/Athird.webp", href: "" },
    { url: "../Images/Afour.webp", href: "" },
    { url: "../Images/Afive.webp", href: "" },
    { url: "../Images/Asix.webp", href: "" },
    { url: "../Images/Aseven.webp", href: "" },
    { url: "../Images/Aeight.webp", href: "" },
];









function showSlides(language) {
    const slideshowContainer = document.querySelector(".slideshow-container");
    slideshowContainer.innerHTML = "";

    let imageUrls;
    if (language === "en") {
        imageUrls = enImageUrls;
    } else if (language === "ar") {
        imageUrls = arImageUrls;
    } else {
        imageUrls = enImageUrls;
    }

    const totalSlides = imageUrls.length;
    if (totalSlides === 0) return;

    for (let i = 0; i < totalSlides; i++) {
        const slideDiv = document.createElement("div");
        slideDiv.className = "mySlides";

        const imgElement = document.createElement("img");
        imgElement.className = "img-fluid";
        imgElement.src = imageUrls[i].url;

        const anchorElement = document.createElement("a");
        anchorElement.href = imageUrls[i].href;
        anchorElement.appendChild(imgElement);

        slideDiv.appendChild(anchorElement);
        slideshowContainer.appendChild(slideDiv);
    }

    slideIndex = 0;
    showSlide(slideIndex);
}

function showSlide(index) {
    const slides = document.getElementsByClassName("mySlides");
        if (index >= slides.length) {
        slideIndex = 0;
        } else if (index < 0) {
        slideIndex = slides.length - 1;
        }
    
        for (let i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
        }
    
        slides[slideIndex].style.display = "flex";
        slideIndex++;
    
        slideshowTimeout = setTimeout(showSlide, 2500, slideIndex);
}

showSlides("en");
